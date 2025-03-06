using System.Security.Claims;
using FullStackCapstone.Data;
using FullStackCapstone.Models;
using FullStackCapstone.Models.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FullStackCapstone.Controllers;

[ApiController]
[Route("api/[controller]")]
public class HouseholdController : ControllerBase
{
    private FullStackCapstoneDbContext _dbContext;

    public HouseholdController(FullStackCapstoneDbContext context)
    {
        _dbContext = context;
    }

    [HttpGet]
    [Authorize]
    public IActionResult GetUserHouseholds()
    {
        var identityUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        var userProfile = _dbContext.UserProfiles.SingleOrDefault(up =>
            up.IdentityUserId == identityUserId
        );
        if (userProfile == null)
            return Unauthorized();

        var currentUsersHouseholdList = _dbContext
            .HouseholdUsers.Where(hu => hu.UserProfileId == userProfile.Id)
            .Include(hu => hu.Household)
            .Select(hu => new { id = hu.HouseholdId, name = hu.Household.Name })
            .ToList();

        return Ok(currentUsersHouseholdList);
    }

    [HttpGet("{householdId}")]
    [Authorize]
    public IActionResult GetExpensesForDashboard([FromRoute] int householdId)
    {

        //check this household exists
        var householdIdCheck = _dbContext.Households.SingleOrDefault(h => h.Id == householdId);
        if (householdIdCheck == null)
        {
            return NotFound();
        }
        //grab each users own expenses and total em up
        var userExpenseTotals = _dbContext
            .Expenses.Where(e => e.HouseholdId == householdId)
            .GroupBy(e => e.PurchasedByUserId)
            .Select(group => new
            {
                UserId = group.Key,
                UserName = _dbContext
                    .UserProfiles.Where(up => up.Id == group.Key)
                    .Select(up => up.FirstName)
                    .FirstOrDefault(),
                Expenses = group.ToList(),
                UserTotal = group.Sum(e => e.Amount),
            })
            .ToList();

        //grab each users own inncomes and total em up
        var userIncomeTotals = _dbContext
            .Incomes.Where(i => i.HouseholdId == householdId)
            .GroupBy(i => i.CreatedById)
            .Select(group => new
            {
                UserId = group.Key,
                UserName = _dbContext
                    .UserProfiles.Where(up => up.Id == group.Key)
                    .Select(up => up.FirstName)
                    .FirstOrDefault(),
                Incomes = group.ToList(),
                UserTotal = group.Sum(i => i.Amount),
            })
            .ToList();

        //total of households expenses
        decimal householdTotalExpense = _dbContext
            .Expenses.Where(e => e.HouseholdId == householdId)
            .Sum(e => e.Amount);

        //total of households incomes
        decimal householdTotalIncome = _dbContext
            .Incomes.Where(i => i.HouseholdId == householdId)
            .Sum(i => i.Amount);

        //easy grab of HouseholdName
        Household household = _dbContext.Households.SingleOrDefault(h => h.Id == householdId);
        var householdName = new HouseholdNameDTO { Id = household.Id, Name = household.Name };

        //now lets grab thte total % of our budget we are using
        decimal activeCategoryTotalBudegt = _dbContext
            .Categories.Where(c => c.IsActive == true)
            .Sum(c => c.CategoryBudgetForTheMonth ?? 0m);

        decimal budgetPercentageUsed = householdTotalExpense / activeCategoryTotalBudegt * 100;

        //assign my variables for clean readabilty/usabilty in return json
        //REMIDER add DTO for this
        var response = new
        {
            UserExpenses = userExpenseTotals,
            HouseholdTotalExpense = householdTotalExpense,
            UserIncomes = userIncomeTotals,
            HouseholdTotalIncome = householdTotalIncome,
            HouseholdName = householdName,
            BudgetTotal = Math.Round(budgetPercentageUsed, 2),
        };

        return Ok(response);
    }
}

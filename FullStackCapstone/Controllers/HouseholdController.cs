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

    [HttpGet("available-households")]
    [Authorize]
    public IActionResult GetNonUserhouseholds()
    {
        var identityUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        var userProfile = _dbContext.UserProfiles.SingleOrDefault(up =>
            up.IdentityUserId == identityUserId
        );
        if (userProfile == null)
            return Unauthorized();

        var availableHouseholds = _dbContext
            .Households.Where(h =>
                !_dbContext
                    .HouseholdUsers.Where(hu => hu.UserProfileId == userProfile.Id)
                    .Select(hu => hu.HouseholdId)
                    .Contains(h.Id)
            )
            .Select(h => new
            {
                id = h.Id,
                name = h.Name,
                members = h
                    .HouseholdUsers.Select(hu => new
                    {
                        id = hu.UserProfile.Id,
                        name = hu.UserProfile.FirstName,
                    })
                    .ToList(),
            })
            .ToList();

        return Ok(availableHouseholds);
    }

    [HttpPost("available-households")]
    [Authorize]
    public IActionResult AddMyselfToNewHousehold([FromBody] int householdId)
    {
        var identityUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        var userProfile = _dbContext.UserProfiles.SingleOrDefault(up =>
            up.IdentityUserId == identityUserId
        );
        if (userProfile == null)
            return Unauthorized();

        var findNewHouse = _dbContext.Households.SingleOrDefault(h => h.Id == householdId);
        if (findNewHouse == null)
        {
            return NotFound($"Household with ID {householdId} not found");
        }

        var newHouseholdUser = new HouseholdUser
        {
            HouseholdId = householdId,
            UserProfileId = userProfile.Id,
        };
        _dbContext.HouseholdUsers.Add(newHouseholdUser);
        _dbContext.SaveChanges();

        return Ok("ADDED");
    }

    [HttpGet("{householdId}")]
    [Authorize]
    public IActionResult GetExpensesForDashboard([FromRoute] int householdId)
    {
        var householdIdCheck = _dbContext.Households.SingleOrDefault(h => h.Id == householdId);
        if (householdIdCheck == null)
        {
            return NotFound();
        }

        var currentMonth = DateTime.Now.Month;
        var currentYear = DateTime.Now.Year;

        var userExpenseTotals = _dbContext
            .Expenses.Where(e =>
                e.HouseholdId == householdId
                && e.DateOfExpense.Month == currentMonth
                && e.DateOfExpense.Year == currentYear
            )
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

        var userIncomeTotals = _dbContext
            .Incomes.Where(i =>
                i.HouseholdId == householdId
                && i.IncomeCreatedDate.Month == currentMonth
                && i.IncomeCreatedDate.Year == currentYear
            )
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

        decimal householdTotalExpense = _dbContext
            .Expenses.Where(e =>
                e.HouseholdId == householdId
                && e.DateOfExpense.Month == currentMonth
                && e.DateOfExpense.Year == currentYear
            )
            .Sum(e => e.Amount);

        decimal householdTotalIncome = _dbContext
            .Incomes.Where(i =>
                i.HouseholdId == householdId
                && i.IncomeCreatedDate.Month == currentMonth
                && i.IncomeCreatedDate.Year == currentYear
            )
            .Sum(i => i.Amount);

        Household household = _dbContext.Households.SingleOrDefault(h => h.Id == householdId);
        var householdName = new HouseholdNameDTO { Id = household.Id, Name = household.Name };

        decimal activeCategoryTotalBudget = _dbContext
            .CategoryBudgets.Where(cb => cb.HouseholdId == householdId)
            .Sum(cb => cb.Category.CategoryBudgetForTheMonth ?? 0m);

        decimal budgetPercentageUsed = 0;
        if (activeCategoryTotalBudget > 0)
        {
            budgetPercentageUsed = householdTotalExpense / activeCategoryTotalBudget * 100;
        }

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

    [HttpGet("all")]
    [Authorize]
    public IActionResult GetAllHouseholds()
    {
        List<HouseholdNameDTO> allHouseholds = _dbContext
            .Households.Where(h => h.IsActive == true)
            .Select(h => new HouseholdNameDTO { Id = h.Id, Name = h.Name })
            .ToList();

        return Ok(allHouseholds);
    }

    [HttpPost]
    [Authorize]
    public IActionResult CreateHousehold(HouseholdPostDTO household)
    {
        Household householdAddition = null;

        using (var transaction = _dbContext.Database.BeginTransaction())
        {
            try
            {
                var identityUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                var userProfile = _dbContext.UserProfiles.SingleOrDefault(up =>
                    up.IdentityUserId == identityUserId
                );

                householdAddition = new Household
                {
                    Name = household.Name,
                    UserProfileId = userProfile.Id,
                };

                _dbContext.Households.Add(householdAddition);
                _dbContext.SaveChanges();

                HouseholdUser addUserToNewHouse = new HouseholdUser
                {
                    HouseholdId = householdAddition.Id,
                    UserProfileId = userProfile.Id,
                    IsAdmin = true,
                };

                _dbContext.HouseholdUsers.Add(addUserToNewHouse);
                _dbContext.SaveChanges();

                var categories = _dbContext.Categories.Where(c => c.IsActive).ToList();

                foreach (var category in categories)
                {
                    var categoryBudget = new CategoryBudget
                    {
                        HouseholdId = householdAddition.Id,
                        CategoryId = category.Id,
                        Month = DateTime.Now,
                        RemainingBudget = category.CategoryBudgetForTheMonth ?? 0m,
                    };

                    _dbContext.CategoryBudgets.Add(categoryBudget);
                }
                _dbContext.SaveChanges();

                transaction.Commit();
            }
            catch
            {
                transaction.Rollback();
                throw;
            }
        }

        return Created($"/api/households/{householdAddition.Id}", householdAddition);
    }
}

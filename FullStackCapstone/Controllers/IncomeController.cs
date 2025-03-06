using System.Security.Claims;
using FullStackCapstone.Data;
using FullStackCapstone.Models;
using FullStackCapstone.Models.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FullStackCapstone.Controllers;

[ApiController]
[Route("api/household/{householdId}/income")]
public class IncomeController : ControllerBase
{
    private FullStackCapstoneDbContext _dbContext;

    public IncomeController(FullStackCapstoneDbContext context)
    {
        _dbContext = context;
    }

    [HttpGet]
    [Authorize]
    public IActionResult GetAllIncomesForHousehold([FromRoute] int householdId)
    {
        var findHouseholdIncomes = _dbContext
            .Incomes.Where(i => i.HouseholdId == householdId).Include(i => i.Frequency)
            .ToList();
        return Ok(findHouseholdIncomes);
    }

    [HttpPost]
    [Authorize]
    public IActionResult Post([FromRoute] int householdId, IncomePostDTO income)
    {
        var identityUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        var userProfile = _dbContext.UserProfiles.SingleOrDefault(up =>
            up.IdentityUserId == identityUserId
        );
        if (userProfile == null)
            return Unauthorized();

        income.HouseholdId = householdId;

        Income addIncome = new Income
        {
            Amount = income.Amount,
            Source = income.Source,
            CreatedById = userProfile.Id,
            IsFavorite = income.IsFavorite,
            IsFrequent = income.IsFrequent,
            FrequencyId = income.FrequencyId,
            HouseholdId = householdId,
        };

        _dbContext.Incomes.Add(addIncome);
        _dbContext.SaveChanges();

        return Created($"api/household/{householdId}/income/{addIncome.Id}", addIncome);
    }

    [HttpDelete("{incomeId}")]
    [Authorize]

    public IActionResult Delete([FromRoute] int householdId, int incomeId)
    {
        var identityUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        var userProfile = _dbContext.UserProfiles.SingleOrDefault(up =>
            up.IdentityUserId == identityUserId
        );
        if (userProfile == null)
            return Unauthorized();

        var householdIncomeList = _dbContext.Incomes.Where(i => i.HouseholdId == householdId);
        var removeIncome = householdIncomeList.SingleOrDefault(I => I.Id == incomeId);

        _dbContext.Incomes.Remove(removeIncome);
        _dbContext.SaveChanges();

        return Ok("deleted");
    }
}

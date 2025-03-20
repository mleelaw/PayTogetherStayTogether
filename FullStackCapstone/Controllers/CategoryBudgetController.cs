using FullStackCapstone.Data;
using FullStackCapstone.Models;
using FullStackCapstone.Models.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FullStackCapstone.Controllers;

[ApiController]
[Route("api/household/{householdId}/budget")]
public class CategoryBudgetController : ControllerBase
{
    private FullStackCapstoneDbContext _dbContext;

    public CategoryBudgetController(FullStackCapstoneDbContext context)
    {
        _dbContext = context;
    }

    [HttpGet]
    [Authorize]
    public IActionResult GetCategoryBudgetsByHousehold([FromRoute] int householdId)
    {
        var categoryBudgets = _dbContext
            .CategoryBudgets.Where(cb =>
                cb.HouseholdId == householdId
                && cb.Month.Month == DateTime.Now.Month
                && cb.Month.Year == DateTime.Now.Year
            )
            .Select(cb => new CategoryBudgetDTO
            {
                CategoryId = cb.CategoryId,
                RemainingBudget = cb.RemainingBudget,
                Month = cb.Month,
            })
            .ToList();

        return Ok(categoryBudgets);
    }
}

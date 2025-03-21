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
        var predefinedCategories = Category.GetPredefinedCategories().ToList();
        var currentMonth = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);

        var existingBudgets = _dbContext
            .CategoryBudgets.Where(cb =>
                cb.HouseholdId == householdId
                && cb.Month.Year == currentMonth.Year
                && cb.Month.Month == currentMonth.Month
                && cb.Month.Day == 1)

            .ToList();


        foreach (var category in predefinedCategories)
        {
            if (!existingBudgets.Any(b => b.CategoryId == category.Id))
            {
                var newBudget = new CategoryBudget
                {
                    HouseholdId = householdId,
                    CategoryId = category.Id,
                    Month = currentMonth,
                    BudgetAmount = 0,
                    RemainingBudget = 0,
                    IsActive = false,
                };

                _dbContext.CategoryBudgets.Add(newBudget);
            }
        }

        if (predefinedCategories.Count > existingBudgets.Count)
        {
            _dbContext.SaveChanges();
        }

        var categoryBudgets = _dbContext
            .CategoryBudgets.Where(cb =>
                cb.HouseholdId == householdId
                && cb.Month.Month == currentMonth.Month
                && cb.Month.Year == currentMonth.Year
                && cb.Month.Day == 1)

            .Select(cb => new CategoryBudgetDTO
            {
                CategoryId = cb.CategoryId,
                CategoryName = cb.Category.Name,
                RemainingBudget = cb.RemainingBudget,
                Month = cb.Month,
            })
            .ToList();

        return Ok(categoryBudgets);
    }
}

using FullStackCapstone.Data;
using FullStackCapstone.Models;
using FullStackCapstone.Models.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FullStackCapstone.Controllers;

[ApiController]
[Route("api/household/{householdId}/category")]
public class CategoryController : ControllerBase
{
    private FullStackCapstoneDbContext _dbContext;

    public CategoryController(FullStackCapstoneDbContext context)
    {
        _dbContext = context;
    }

    [HttpGet]
    [Authorize]
    public IActionResult GetCategories([FromRoute] int householdId)
    {
        try
        {
            var predefinedCategories = Category.GetPredefinedCategories().ToList();
            var currentMonth = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            var existingBudgets = _dbContext.CategoryBudgets
     .Where(cb =>
         cb.HouseholdId == householdId &&
         cb.Month.Year == currentMonth.Year &&
         cb.Month.Month == currentMonth.Month &&
         cb.Month.Day == 1)
     .Include(cb => cb.Category)
     .ToList();


            var categories = existingBudgets.Select(cb => new
            {
                id = cb.Category.Id,
                name = cb.Category.Name,
                isActive = cb.IsActive,
                categoryBudgetForTheMonth = cb.BudgetAmount
            }).ToList();

            decimal totalBudget = existingBudgets
                .Where(cb => cb.IsActive)
                .Sum(cb => cb.BudgetAmount);

            return Ok(new { categories, totalBudget });
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Error getting categories: {ex.Message}");
        }
    }

    [HttpPut("{categoryId}")]
    [Authorize]
    public IActionResult UpdateCategory(
      [FromRoute] int categoryId,
      [FromRoute] int householdId,
      [FromBody] CategoryUpdateDTO categoryDto)
    {
        using var transaction = _dbContext.Database.BeginTransaction();

        try
        {
            var category = _dbContext.Categories.Find(categoryId);
            if (category == null)
                return NotFound("Category not found");

            var currentMonth = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            var currentMonthBudget = _dbContext.CategoryBudgets.FirstOrDefault(cb =>
                cb.CategoryId == categoryId &&
                cb.HouseholdId == householdId &&
                cb.Month.Year == currentMonth.Year &&
                cb.Month.Month == currentMonth.Month &&
                cb.Month.Day == 1);

            if (currentMonthBudget == null)
            {
                currentMonthBudget = new CategoryBudget
                {
                    CategoryId = categoryId,
                    HouseholdId = householdId,
                    Month = currentMonth,
                    BudgetAmount = categoryDto.BudgetAmount ?? 0m,
                    RemainingBudget = categoryDto.BudgetAmount ?? 0m,
                    IsActive = categoryDto.IsActive,
                };
                _dbContext.CategoryBudgets.Add(currentMonthBudget);
            }
            else
            {
                decimal budgetDifference = (categoryDto.BudgetAmount ?? 0) - currentMonthBudget.BudgetAmount;
                currentMonthBudget.IsActive = categoryDto.IsActive;
                currentMonthBudget.BudgetAmount = categoryDto.BudgetAmount ?? 0m;
                currentMonthBudget.RemainingBudget += budgetDifference;
            }

            _dbContext.SaveChanges();
            transaction.Commit();

            return Ok(currentMonthBudget);
        }
        catch (Exception ex)
        {
            transaction.Rollback();
            return StatusCode(500, $"Error updating category: {ex.Message}");
        }
    }
    [HttpGet("remaining")]
    [Authorize]
    public IActionResult GetCategoryRemainingBudget(int categoryId, [FromRoute] int householdId)
    {
        var currentMonth = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
        var categoryBudget = _dbContext.CategoryBudgets.FirstOrDefault(cb =>
            cb.CategoryId == categoryId
            && cb.HouseholdId == householdId
            && cb.Month.Month == currentMonth.Month
            && cb.Month.Year == currentMonth.Year
        );

        if (categoryBudget == null)
        {
            return NotFound("CategoryBudget not found for the selected month.");
        }

        return Ok(new { RemainingBudget = categoryBudget.RemainingBudget });
    }
}

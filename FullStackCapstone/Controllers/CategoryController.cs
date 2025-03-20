using FullStackCapstone.Data;
using FullStackCapstone.Models.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FullStackCapstone.Controllers;

[ApiController]
[Route("api/category")]
public class CategoryController : ControllerBase
{
    private FullStackCapstoneDbContext _dbContext;

    public CategoryController(FullStackCapstoneDbContext context)
    {
        _dbContext = context;
    }
    [HttpPut("{categoryId}")]
    [Authorize]
    public IActionResult UpdateCategory(
    [FromRoute] int categoryId,
    [FromQuery] int householdId,
    [FromBody] CategoryUpdateDTO categoryDto
)
    {
        // Verify the category exists
        var category = _dbContext.Categories.Find(categoryId);
        if (category == null)
            return NotFound("Category not found");

        // Verify the household exists
        var household = _dbContext.Households.Find(householdId);
        if (household == null)
            return NotFound("Household not found");

        // Find all category budgets for this category and household
        var categoryBudgets = _dbContext.CategoryBudgets
            .Where(cb => cb.CategoryId == categoryId && cb.HouseholdId == householdId)
            .ToList();

        // If no budgets exist yet for the current month, create one
        var currentMonth = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
        var currentMonthBudget = categoryBudgets.FirstOrDefault(cb =>
            cb.Month.Year == currentMonth.Year && cb.Month.Month == currentMonth.Month);

        if (currentMonthBudget == null)
        {
            currentMonthBudget = new CategoryBudget
            {
                CategoryId = categoryId,
                HouseholdId = householdId,
                Month = currentMonth,
                BudgetAmount = categoryDto.BudgetAmount ?? 0m,
                RemainingBudget = categoryDto.BudgetAmount ?? 0m,
                IsActive = categoryDto.IsActive
            };
            _dbContext.CategoryBudgets.Add(currentMonthBudget);
            categoryBudgets.Add(currentMonthBudget);
        }
        else
        {
            // Update current month's budget
            currentMonthBudget.IsActive = categoryDto.IsActive;
            currentMonthBudget.BudgetAmount = categoryDto.BudgetAmount ?? 0m;

            // Recalculate remaining budget
            var totalExpenses = _dbContext.Expenses
                .Where(e =>
                    e.CategoryBudgetId == currentMonthBudget.Id ||
                    (e.CategoryId == categoryId && e.HouseholdId == householdId &&
                    e.DateOfExpense.Month == currentMonth.Month &&
                    e.DateOfExpense.Year == currentMonth.Year)
                )
                .Sum(e => e.Amount);

            currentMonthBudget.RemainingBudget = currentMonthBudget.BudgetAmount - totalExpenses;
        }

        // If the category name has changed, update it in the base category
        if (category.Name != categoryDto.Name)
        {
            category.Name = categoryDto.Name;
        }

        _dbContext.SaveChanges();

        // Return the updated category with household-specific settings
        var result = new CategoryBudgetDTO
        {
            CategoryId = category.Id,
            CategoryName = category.Name,
            IsActive = currentMonthBudget.IsActive,
            BudgetAmount = currentMonthBudget.BudgetAmount,
            RemainingBudget = currentMonthBudget.RemainingBudget,
            TotalExpenses = currentMonthBudget.BudgetAmount - currentMonthBudget.RemainingBudget,
            Month = currentMonth
        };

        return Ok(result);
    }
    [HttpGet]
    [Authorize]
    public IActionResult GetCategoryRemainingBudget(int categoryId, int householdId)
    {
        var categoryBudget = _dbContext.CategoryBudgets.FirstOrDefault(cb =>
            cb.CategoryId == categoryId
            && cb.HouseholdId == householdId
            && cb.Month.Month == DateTime.Now.Month
            && cb.Month.Year == DateTime.Now.Year
        );

        if (categoryBudget == null)
        {
            return NotFound("CategoryBudget not found for the selected month.");
        }

        return Ok(new { RemainingBudget = categoryBudget.RemainingBudget });
    }
}

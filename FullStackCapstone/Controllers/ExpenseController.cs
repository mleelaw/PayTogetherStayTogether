using System.Security.Claims;
using FullStackCapstone.Data;
using FullStackCapstone.Models;
using FullStackCapstone.Models.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FullStackCapstone.Controllers;

[ApiController]
[Route("api/household/{householdId}/expense")]
public class ExpenseController : ControllerBase
{
    private FullStackCapstoneDbContext _dbContext;

    public ExpenseController(FullStackCapstoneDbContext context)
    {
        _dbContext = context;
    }

    [HttpPost]
    [Authorize]
    public IActionResult PostExpense(ExpensePostDTO expense)
    {
        using var transaction = _dbContext.Database.BeginTransaction();

        try
        {
            // Check if there's an existing CategoryBudget for this month
            var findCategoryBudgetForThisExpense = _dbContext.CategoryBudgets.FirstOrDefault(cb =>
                cb.CategoryId == expense.CategoryId
                && cb.HouseholdId == expense.HouseholdId
                && cb.Month.Month == expense.DateOfExpense.Month
                && cb.Month.Year == expense.DateOfExpense.Year
            );

            // Create a new CategoryBudget if none found
            if (findCategoryBudgetForThisExpense == null)
            {
                findCategoryBudgetForThisExpense = new CategoryBudget
                {
                    HouseholdId = expense.HouseholdId,
                    CategoryId = expense.CategoryId,
                    Month = new DateTime(expense.DateOfExpense.Year, expense.DateOfExpense.Month, 1),
                    RemainingBudget = 0, // Or maybe start with the category's budget if applicable?
                };

                _dbContext.CategoryBudgets.Add(findCategoryBudgetForThisExpense);
                _dbContext.SaveChanges(); // Save the new budget
            }

            // Deduct the expense amount from the RemainingBudget
            findCategoryBudgetForThisExpense.RemainingBudget -= expense.Amount;
            _dbContext.CategoryBudgets.Update(findCategoryBudgetForThisExpense);

            // Create the Expense
            Expense addExpense = new Expense
            {
                HouseholdId = expense.HouseholdId,
                Amount = expense.Amount,
                CategoryId = expense.CategoryId,
                Description = expense.Description,
                DateOfExpense = expense.DateOfExpense,
                PurchasedByUserId = expense.PurchasedByUserId,
                IsFavorite = expense.IsFavorite,
                IsRecurring = expense.IsRecurring,
                FrequencyId = expense.FrequencyId,
            };

            _dbContext.Expenses.Add(addExpense);

            // Save both changes in one go
            _dbContext.SaveChanges();
            transaction.Commit();

            return Created("expense", addExpense);
        }
        catch (Exception ex)
        {
            transaction.Rollback();
            return StatusCode(500, $"Error: {ex.Message}");
        }
    }


    [HttpGet]
    [Authorize]
    public IActionResult GetAllExpensesForHousehold(
        [FromRoute] int householdId,
        [FromQuery] int? month,
        [FromQuery] int? year
    )
    {
        var query = _dbContext
            .Expenses.Where(e => e.HouseholdId == householdId)
            .Include(e => e.Category)
            .Include(e => e.PurchasedBy)
            .Include(e => e.Frequency)
            .AsQueryable();

        if (year.HasValue)
        {
            query = query.Where(e => e.DateOfExpense.Year == year.Value);
        }

        if (month.HasValue)
        {
            query = query.Where(e => e.DateOfExpense.Month == month.Value);
        }

        var expenses = query.ToList();
        return Ok(expenses);
    }

    [HttpDelete("{expenseId}")]
    [Authorize]
    public IActionResult Delete([FromRoute] int householdId, int expenseId)
    {
        var identityUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        var userProfile = _dbContext.UserProfiles.SingleOrDefault(up =>
            up.IdentityUserId == identityUserId
        );
        if (userProfile == null)
            return Unauthorized();

        var householdExpenseList = _dbContext.Expenses.Where(e => e.HouseholdId == householdId);
        var removeExpense = householdExpenseList.SingleOrDefault(e => e.Id == expenseId);

        if (removeExpense == null)
        {
            return NotFound("Expense not found");
        }

        // Get the associated CategoryBudget
        var categoryBudget = _dbContext.CategoryBudgets.SingleOrDefault(cb =>
            cb.HouseholdId == householdId
            && cb.CategoryId == removeExpense.CategoryId
            && cb.Month.Month == DateTime.Now.Month
            && // Use cb.Date.Month
            cb.Month.Year == DateTime.Now.Year // Use cb.Date.Year
        );

        if (categoryBudget != null)
        {
            // Update the remaining budget
            categoryBudget.RemainingBudget += removeExpense.Amount;
        }

        _dbContext.Expenses.Remove(removeExpense);
        _dbContext.SaveChanges();

        return Ok("Expense deleted and budget updated.");
    }

    [HttpGet("categories")]
    [Authorize]
    public IActionResult GetCategories()
    {
        var categories = _dbContext.Categories.ToList();
        decimal totalBudget = _dbContext
            .Categories.Where(c => c.IsActive)
            .Sum(c => c.CategoryBudgetForTheMonth ?? 0);

        return Ok(new { Categories = categories, TotalBudget = totalBudget });
    }

    [HttpGet("{expenseId}")]
    [Authorize]
    public IActionResult GetExpenseById([FromRoute] int householdId, int expenseId)
    {
        var expense = _dbContext
            .Expenses.Include(e => e.Category)
            .Include(e => e.PurchasedBy)
            .Include(e => e.Frequency)
            .SingleOrDefault(e => e.Id == expenseId && e.HouseholdId == householdId);

        return Ok(expense);
    }

    [HttpPut("{expenseId}")]
    [Authorize]
    public IActionResult UpdateExpense(
        [FromRoute] int householdId,
        int expenseId,
        ExpensePostDTO expense
    )
    {
        var expenseToUpdate = _dbContext.Expenses.SingleOrDefault(e =>
            e.Id == expenseId && e.HouseholdId == householdId
        );

        expenseToUpdate.Amount = expense.Amount;
        expenseToUpdate.CategoryId = expense.CategoryId;
        expenseToUpdate.Description = expense.Description;
        expenseToUpdate.DateOfExpense = expense.DateOfExpense;
        expenseToUpdate.IsRecurring = expense.IsRecurring;
        expenseToUpdate.FrequencyId = expense.FrequencyId;
        expenseToUpdate.IsFavorite = expense.IsFavorite;

        _dbContext.SaveChanges();

        return Ok(expenseToUpdate);
    }
}

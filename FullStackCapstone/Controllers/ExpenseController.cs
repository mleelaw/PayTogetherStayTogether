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
        _dbContext.SaveChanges();

        return Created("expense", addExpense);
    }

    [HttpGet]
    [Authorize]
    public IActionResult GetAllExpensesForHousehold([FromRoute] int householdId)
    {
        var expenseList = _dbContext
            .Expenses.Where(e => e.HouseholdId == householdId)
            .Include(e => e.Category)
            .Include(e => e.PurchasedBy)
            .Include(e => e.Frequency)
            .ToList();

        return Ok(expenseList);
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

        _dbContext.Expenses.Remove(removeExpense);
        _dbContext.SaveChanges();

        return Ok("deleted");
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

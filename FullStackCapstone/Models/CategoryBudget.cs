using System.ComponentModel.DataAnnotations;

namespace FullStackCapstone.Models;

public class CategoryBudget
{
    public int Id { get; set; }

    [Required]
    public int CategoryId { get; set; }

    [Required]
    public int HouseholdId { get; set; }

    [Required]
    public DateTime Month { get; set; }

    [Required]
    public bool IsActive { get; set; } = true;

    [Required]
    public decimal BudgetAmount { get; set; }

    [Required]
    public decimal RemainingBudget { get; set; }

    // Navigation properties
    public Category Category { get; set; }
    public Household Household { get; set; }

    public List<Expense> Expenses { get; set; } = new List<Expense>();

    // Constructors and methods
    public CategoryBudget() { }

    public CategoryBudget(Category category, Household household, DateTime month, decimal budgetAmount = 0)
    {
        CategoryId = category.Id;
        HouseholdId = household.Id;
        Month = month;
        BudgetAmount = budgetAmount;
        RemainingBudget = budgetAmount;
        IsActive = true;
    }

    public void UpdateRemainingBudget()
    {
        RemainingBudget = BudgetAmount - TotalExpenses;
    }

    public decimal TotalExpenses => Expenses.Sum(e => e.Amount);

    public bool IsOverBudget => TotalExpenses > BudgetAmount;
}

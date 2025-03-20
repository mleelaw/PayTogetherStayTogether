using System.ComponentModel.DataAnnotations;

namespace FullStackCapstone.Models;

public class Household
{
    public int Id { get; set; }

    [Required]
    public string Name { get; set; }

    public DateTime CreatedDate { get; } = DateTime.Now;

    public bool IsActive { get; set; } = true;

    [Required]
    public int UserProfileId { get; set; } //user who created the household!

    public UserProfile UserProfile { get; set; }

    public List<HouseholdUser> HouseholdUsers { get; set; } = new List<HouseholdUser>();

    public List<Expense> Expenses { get; set; } = new List<Expense>();

    public List<CategoryBudget> CategoryBudgets { get; set; } = new List<CategoryBudget>();

    public List<Income> Incomes { get; set; } = new List<Income>();
    public decimal TotalOfExpenses()
    {

        return Expenses?.Sum(e => e.Amount) ?? 0m;
    }

}

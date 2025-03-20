using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FullStackCapstone.Models;

public class Expense
{
    public int Id { get; set; }

    [Required]
    public int HouseholdId { get; set; }

    public Household Household { get; set; }
    [Required]
    public decimal Amount { get; set; }

    [Required]
    public int CategoryBudgetId { get; set; }

    public CategoryBudget CategoryBudget { get; set; }
    public int CategoryId { get; set; }

    public Category Category { get; set; }

    [Required]
    [StringLength(50)]
    public string Description { get; set; }
    [Required]
    public DateTime DateOfExpense { get; set; }

    public DateTime DateExpenseWasRecorded { get; } = DateTime.Now;

    [Required]
    [ForeignKey("PurchasedBy")]
    public int PurchasedByUserId { get; set; }

    public UserProfile PurchasedBy { get; set; }

    public bool IsRecurring { get; set; } = false;

    public int? FrequencyId { get; set; }

    public Frequency? Frequency { get; set; }
    public bool? IsFavorite { get; set; } = false;



}

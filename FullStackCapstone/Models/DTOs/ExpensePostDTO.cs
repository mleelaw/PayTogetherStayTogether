
namespace FullStackCapstone.Models.DTOs;

public class ExpensePostDTO
{
    public int Id { get; set; }

    public int HouseholdId { get; set; }

    public decimal Amount { get; set; }


    public int CategoryId { get; set; }

    public string Description { get; set; }

    public DateTime DateOfExpense { get; set; }

    public int PurchasedByUserId { get; set; }

    public bool IsRecurring { get; set; } = false;

    public int? FrequencyId { get; set; }
    public bool? IsFavorite { get; set; } = false;

}
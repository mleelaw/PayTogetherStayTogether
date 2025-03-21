using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FullStackCapstone.Models.DTOs;

public class ExpenseDTO
{
    public int Id { get; set; }

    public int HouseholdId { get; set; }

    public decimal Amount { get; set; }


    public int CategoryId { get; set; }

    public int? CategoryBudgetId { get; set; }

    public string Description { get; set; }

    public DateTime DateOfExpense { get; set; }

    public DateTime DateExpenseWasRecorded { get; } = DateTime.Now;


    public int PurchasedByUserId { get; set; }



    public bool? isRecurring { get; set; } = false;

    public int? FrequencyId { get; set; }
    public bool? IsFavorite { get; set; } = false;



}
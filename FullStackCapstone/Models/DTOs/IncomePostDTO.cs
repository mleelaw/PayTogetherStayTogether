using System.ComponentModel.DataAnnotations;


namespace FullStackCapstone.Models.DTOs;

public class IncomePostDTO
{
    public int Id { get; set; }

    public decimal Amount { get; set; }
    [Required]
    [StringLength(25)]
    public string Source { get; set; }
    public int CreatedById { get; set; }

    public bool IsFavorite { get; set; } = false;

    public bool? IsFrequent { get; set; } = false;

    public int? FrequencyId { get; set; }

    public int HouseholdId { get; set; }


}
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace FullStackCapstone.Models;

public class Income
{
    public int Id { get; set; }
    [Required]
    public decimal Amount { get; set; }
    [Required]
    [StringLength(25)]
    public string Source { get; set; }

    [ForeignKey("Creator")]
    public int CreatedById { get; set; }
    public UserProfile Creator { get; set; }

    public DateTime IncomeCreatedDate { get; private set; } = DateTime.Now;

    public bool IsFavorite { get; set; } = false;

    public bool? IsFrequent { get; set; } = false;

    public int? FrequencyId { get; set; }

    public Frequency? Frequency { get; set; }

    [Required]
    public int HouseholdId { get; set; }
    public Household Household { get; set; }

}
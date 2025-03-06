using System.ComponentModel.DataAnnotations;

namespace FullStackCapstone.Models;

public class HouseholdUser
{
    public int Id { get; set; }

    [Required]
    public int HouseholdId { get; set; }

    public Household Household { get; set; }

    [Required]
    public int UserProfileId { get; set; }

    public UserProfile UserProfile { get; set; }

    public DateTime JoinDate { get; } = DateTime.Now;
    public bool IsActive { get; set; } = true;

    public bool IsAdmin { get; set; } = true;
}

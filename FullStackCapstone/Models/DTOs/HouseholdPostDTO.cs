using System.ComponentModel.DataAnnotations;

namespace FullStackCapstone.Models.DTOs;

public class HouseholdPostDTO
{
    public int Id { get; set; }

    [Required]
    public string Name { get; set; }

    public DateTime CreatedDate { get; } = DateTime.Now;

    public bool IsActive { get; set; } = true;

    [Required]
    public int UserProfileId { get; set; }


}
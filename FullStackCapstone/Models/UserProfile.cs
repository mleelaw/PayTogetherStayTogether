using Microsoft.AspNetCore.Identity;

namespace FullStackCapstone.Models;

public class UserProfile
{
    public int Id { get; set; }
    public string IdentityUserId { get; set; }
    //connection to the ASP.Net identity system
    public IdentityUser IdentityUser { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Address { get; set; }

    public List<HouseholdUser> HouseholdUsers { get; set; } = new List<HouseholdUser>();
}

using System.Security.Claims;
using FullStackCapstone.Data;
using FullStackCapstone.Models;
using FullStackCapstone.Models.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FullStackCapstone.Controllers;

[ApiController]
[Route("api/[controller]")]
public class HouseholdUserController : ControllerBase
{
    private FullStackCapstoneDbContext _dbContext;

    public HouseholdUserController(FullStackCapstoneDbContext context)
    {
        _dbContext = context;
    }

    [HttpDelete("{householdId}")]
    [Authorize]
    public IActionResult DeleteHouseholdUser([FromRoute] int householdId)
    {
        var identityUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        var userProfile = _dbContext.UserProfiles.SingleOrDefault(up =>
            up.IdentityUserId == identityUserId
        );
        if (userProfile == null)
            return Unauthorized();

        var findHouseholdUser = _dbContext.HouseholdUsers.Single(hu =>
            hu.HouseholdId == householdId && hu.UserProfileId == userProfile.Id
        );

        _dbContext.HouseholdUsers.Remove(findHouseholdUser);
        _dbContext.SaveChanges();

        return Ok("deleted");
    }
}

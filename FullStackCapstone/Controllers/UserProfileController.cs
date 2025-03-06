using FullStackCapstone.Data;
using FullStackCapstone.Models.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FullStackCapstone.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserProfileController : ControllerBase
{
    private FullStackCapstoneDbContext _dbContext;

    public UserProfileController(FullStackCapstoneDbContext context)
    {
        _dbContext = context;
    }

    [HttpGet]
    [Authorize]
    public IActionResult Get()
    {
        return Ok(
            _dbContext
                .UserProfiles.Include(up => up.IdentityUser)
                .Select(up => new UserProfileDTO
                {
                    Id = up.Id,
                    FirstName = up.FirstName,
                    LastName = up.LastName,
                    Address = up.Address,
                    IdentityUserId = up.IdentityUserId,
                    Email = up.IdentityUser.Email,
                    UserName = up.IdentityUser.UserName,
                })
                .ToList()
        );
    }
}

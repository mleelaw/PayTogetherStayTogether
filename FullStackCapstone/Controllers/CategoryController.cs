using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using FullStackCapstone.Data;
using FullStackCapstone.Models.DTOs;

namespace FullStackCapstone.Controllers;

[ApiController]
[Route("api/category")]
public class CategoryController : ControllerBase
{
    private FullStackCapstoneDbContext _dbContext;

    public CategoryController(FullStackCapstoneDbContext context)
    {
        _dbContext = context;
    }

    [HttpPut("{categoryId}")]
    [Authorize]
    public IActionResult UpdateCategory([FromRoute] int categoryId, CategoryUpdateDTO category)
    {
        var categoryToUpdate = _dbContext.Categories.Find(categoryId);

        if (categoryToUpdate == null)
            return NotFound();

        categoryToUpdate.Name = category.Name;
        categoryToUpdate.IsActive = category.IsActive;
        categoryToUpdate.CategoryBudgetForTheMonth = category.CategoryBudgetForTheMonth;

        _dbContext.SaveChanges();

        return Ok(categoryToUpdate);
    }
}
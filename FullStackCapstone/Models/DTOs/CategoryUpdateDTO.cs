namespace FullStackCapstone.Models.DTOs;

public class CategoryUpdateDTO
{
    public string Name { get; set; }
    public bool IsActive { get; set; }
    public decimal? CategoryBudgetForTheMonth { get; set; }
}
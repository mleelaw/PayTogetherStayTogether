namespace FullStackCapstone.Models;

public class Category
{
    public int Id { get; set; }
    public string Name { get; set; }

    public List<CategoryBudget> CategoryBudgets { get; set; } = new List<CategoryBudget>();
    public static readonly int RentId = 1;
    public static readonly int GroceriesId = 2;
    public static readonly int PetExpensesId = 3;

    public static readonly string Rent = "Rent";
    public static readonly string Groceries = "Groceries";
    public static readonly string PetExpenses = "Pet Expenses";

    public static IEnumerable<Category> GetPredefinedCategories()
    {
        return new[]
        {
            new Category { Id = RentId, Name = Rent },
            new Category { Id = GroceriesId, Name = Groceries },
            new Category { Id = PetExpensesId, Name = PetExpenses },
        };
    }
}

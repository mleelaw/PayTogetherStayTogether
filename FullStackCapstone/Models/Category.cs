namespace FullStackCapstone.Models;

public class Category
{

    public int Id { get; set; }
    public string Name { get; set; }
    public bool IsActive { get; set; } = true;
    public decimal? CategoryBudgetForTheMonth { get; set; }

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
            new Category
            {
                Id = RentId,
                Name = Rent,
                CategoryBudgetForTheMonth = 2000.00m,
                IsActive = true,
            },
            new Category
            {
                Id = GroceriesId,
                Name = Groceries,
                CategoryBudgetForTheMonth = 1000.00m,
                IsActive = true,
            },
            new Category
            {
                Id = PetExpensesId,
                Name = PetExpenses,
                CategoryBudgetForTheMonth = 150.00m,
                IsActive = true,
            },
        };
    }
}

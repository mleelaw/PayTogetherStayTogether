namespace FullStackCapstone.Models;

public class Category
{
    //all category instances have these 4 attributes
    public int Id { get; set; }
    public string Name { get; set; }
    public bool IsActive { get; set; } = true;
    public decimal? CategoryBudgetForTheMonth { get; set; }

    //these are defining the ids for the predefined cats in GetPredefinedCategories
    public static readonly int RentId = 1;
    public static readonly int GroceriesId = 2;
    public static readonly int PetExpensesId = 3;

    //same as above but with category names
    public static readonly string Rent = "Rent";
    public static readonly string Groceries = "Groceries";
    public static readonly string PetExpenses = "Pet Expenses";

    //creating a list of my category instances to be able to call upon, centralizing
    // this here makes maintanence easier
    // ienumerable is just a collection of objects that can be iterated over
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

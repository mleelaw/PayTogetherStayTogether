using FullStackCapstone.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FullStackCapstone.Data;

public class FullStackCapstoneDbContext : IdentityDbContext<IdentityUser>
{
    private readonly IConfiguration _configuration;

    public DbSet<UserProfile> UserProfiles { get; set; }
    public DbSet<Category> Categories { get; set; }

    public DbSet<Expense> Expenses { get; set; }

    public DbSet<Frequency> Frequencies { get; set; }
    public DbSet<Household> Households { get; set; }

    public DbSet<HouseholdUser> HouseholdUsers { get; set; }

    public DbSet<Income> Incomes { get; set; }

    public DbSet<CategoryBudget> CategoryBudgets { get; set; }

    public FullStackCapstoneDbContext(
        DbContextOptions<FullStackCapstoneDbContext> context,
        IConfiguration config
    )
        : base(context)
    {
        _configuration = config;
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder
            .Entity<IdentityRole>()
            .HasData(
                new IdentityRole
                {
                    Id = "c3aaeb97-d2ba-4a53-a521-4eea61e59b35",
                    Name = "Admin",
                    NormalizedName = "admin",
                },
                new IdentityRole
                {
                    Id = "dfcde332-19d2-4078-8deb-72f54818bf20",
                    Name = "User",
                    NormalizedName = "USER",
                }
            );

        modelBuilder
            .Entity<IdentityUser>()
            .HasData(
                new IdentityUser
                {
                    Id = "dbc40bc6-0829-4ac5-a3ed-180f5e916a5f",
                    UserName = "Administrator",
                    Email = "admina@strator.comx",
                    PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(
                        null,
                        _configuration["AdminPassword"]
                    ),
                },
                new IdentityUser
                {
                    Id = "someOtherUserId123456789",
                    UserName = "MLee",
                    Email = "mleelaw123@gmail.com",
                    PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(
                        null,
                        _configuration["AdminPassword"]
                    ),
                },
                new IdentityUser
                {
                    Id = "someOtherUserId123456788",
                    UserName = "Abigail",
                    Email = "maezell@gmail.com",
                    PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(
                        null,
                        _configuration["AdminPassword"]
                    ),
                }
            );

        modelBuilder
            .Entity<IdentityUserRole<string>>()
            .HasData(
                new IdentityUserRole<string>
                {
                    RoleId = "c3aaeb97-d2ba-4a53-a521-4eea61e59b35",
                    UserId = "dbc40bc6-0829-4ac5-a3ed-180f5e916a5f",
                },
                new IdentityUserRole<string>
                {
                    RoleId = "c3aaeb97-d2ba-4a53-a521-4eea61e59b35",
                    UserId = "someOtherUserId123456789",
                },
                new IdentityUserRole<string>
                {
                    RoleId = "dfcde332-19d2-4078-8deb-72f54818bf20",
                    UserId = "someOtherUserId123456788",
                }
            );
        modelBuilder
            .Entity<UserProfile>()
            .HasData(
                new UserProfile
                {
                    Id = 1,
                    IdentityUserId = "dbc40bc6-0829-4ac5-a3ed-180f5e916a5f",
                    FirstName = "Admina",
                    LastName = "Strator",
                    Address = "101 Main Street",
                },
                new UserProfile
                {
                    Id = 2,
                    IdentityUserId = "someOtherUserId123456789",
                    FirstName = "MLee",
                    LastName = "Law",
                    Address = "123 Street Road",
                },
                new UserProfile
                {
                    Id = 3,
                    IdentityUserId = "someOtherUserId123456788",
                    FirstName = "Abigail",
                    LastName = "Ezell",
                    Address = "123 Street Road",
                }
            );

        modelBuilder.Entity<Category>().HasData(Category.GetPredefinedCategories());

        modelBuilder.Entity<Frequency>().HasData(Frequency.GetPredefinedFrequencies());

        modelBuilder
            .Entity<Household>()
            .HasData(
                new Household
                {
                    Id = 1,
                    Name = "She & Her",
                    IsActive = true,
                    UserProfileId = 2,
                },
                new Household
                {
                    Id = 2,
                    Name = "My Other Family",
                    IsActive = true,
                    UserProfileId = 1,
                }
            );

        modelBuilder
            .Entity<HouseholdUser>()
            .HasData(
                new HouseholdUser
                {
                    Id = 1,
                    HouseholdId = 1,
                    UserProfileId = 2,
                    IsActive = true,
                    IsAdmin = true,
                },
                new HouseholdUser
                {
                    Id = 2,
                    HouseholdId = 1,
                    UserProfileId = 3,
                    IsActive = true,
                    IsAdmin = false,
                },
                new HouseholdUser
                {
                    Id = 3,
                    HouseholdId = 2,
                    UserProfileId = 1,
                    IsActive = true,
                    IsAdmin = false,
                },
                new HouseholdUser
                {
                    Id = 4,
                    HouseholdId = 2,
                    UserProfileId = 3,
                    IsActive = true,
                    IsAdmin = false,
                }
            );

        modelBuilder
            .Entity<CategoryBudget>()
            .HasData(
                new CategoryBudget
                {
                    Id = 1,
                    CategoryId = 1, // Rent
                    HouseholdId = 1,
                    Month = new DateTime(2023, 3, 1),
                    BudgetAmount = 2000.00m,
                    RemainingBudget = 100.00m,
                    IsActive = true,
                },
                new CategoryBudget
                {
                    Id = 2,
                    CategoryId = 2, // Groceries
                    HouseholdId = 1,
                    Month = new DateTime(2023, 3, 1),
                    BudgetAmount = 1000.00m,
                    RemainingBudget = 967.00m,
                    IsActive = true,
                },
                new CategoryBudget
                {
                    Id = 3,
                    CategoryId = 3, // Pet Expenses
                    HouseholdId = 1,
                    Month = new DateTime(2023, 3, 1),
                    BudgetAmount = 150.00m,
                    RemainingBudget = 114.00m,
                    IsActive = true,
                },
                new CategoryBudget
                {
                    Id = 4,
                    CategoryId = 1, // Rent
                    HouseholdId = 2,
                    Month = new DateTime(2023, 3, 1),
                    BudgetAmount = 2000.00m,
                    RemainingBudget = 100.00m,
                    IsActive = true,
                }
            );
        modelBuilder
            .Entity<Income>()
            .HasData(
                new Income
                {
                    Id = 1,
                    Amount = 0.10m,
                    Source = "Student",
                    CreatedById = 2,
                    IsFavorite = false,
                    IsFrequent = false,
                    HouseholdId = 1,
                },
                new Income
                {
                    Id = 2,
                    Amount = 2400m,
                    Source = "Work",
                    CreatedById = 3,
                    IsFavorite = true,
                    IsFrequent = true,
                    HouseholdId = 1,
                    FrequencyId = 3,
                },
                new Income
                {
                    Id = 3,
                    Amount = 2400m,
                    Source = "Work",
                    CreatedById = 1,
                    IsFavorite = true,
                    IsFrequent = true,
                    HouseholdId = 2,
                    FrequencyId = 3,
                }
            );
    }
}

﻿// <auto-generated />
using System;
using FullStackCapstone.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace FullStackCapstone.Migrations
{
    [DbContext(typeof(FullStackCapstoneDbContext))]
    [Migration("20250306023055_UpdatedExpenseModelForNullableBoolIsRecurring")]
    partial class UpdatedExpenseModelForNullableBoolIsRecurring
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("FullStackCapstone.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<decimal?>("CategoryBudgetForTheMonth")
                        .HasColumnType("numeric");

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CategoryBudgetForTheMonth = 2000.00m,
                            IsActive = true,
                            Name = "Rent"
                        },
                        new
                        {
                            Id = 2,
                            CategoryBudgetForTheMonth = 1000.00m,
                            IsActive = true,
                            Name = "Groceries"
                        },
                        new
                        {
                            Id = 3,
                            CategoryBudgetForTheMonth = 150.00m,
                            IsActive = true,
                            Name = "Pet Expenses"
                        });
                });

            modelBuilder.Entity("FullStackCapstone.Models.Expense", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<decimal>("Amount")
                        .HasColumnType("numeric");

                    b.Property<int>("CategoryId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("DateOfExpense")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<int?>("FrequencyId")
                        .HasColumnType("integer");

                    b.Property<int>("HouseholdId")
                        .HasColumnType("integer");

                    b.Property<bool?>("IsFavorite")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsRecurring")
                        .HasColumnType("boolean");

                    b.Property<int>("PurchasedByUserId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("FrequencyId");

                    b.HasIndex("HouseholdId");

                    b.HasIndex("PurchasedByUserId");

                    b.ToTable("Expenses");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Amount = 36.00m,
                            CategoryId = 3,
                            DateOfExpense = new DateTime(2023, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Nail Trim at Belmont Animal Hospital",
                            FrequencyId = 5,
                            HouseholdId = 1,
                            IsFavorite = true,
                            IsRecurring = true,
                            PurchasedByUserId = 2
                        },
                        new
                        {
                            Id = 2,
                            Amount = 33.00m,
                            CategoryId = 2,
                            DateOfExpense = new DateTime(2023, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "WaffleHouse",
                            HouseholdId = 1,
                            IsFavorite = false,
                            IsRecurring = false,
                            PurchasedByUserId = 3
                        },
                        new
                        {
                            Id = 3,
                            Amount = 1900m,
                            CategoryId = 1,
                            DateOfExpense = new DateTime(2023, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Rent",
                            FrequencyId = 4,
                            HouseholdId = 1,
                            IsFavorite = true,
                            IsRecurring = true,
                            PurchasedByUserId = 3
                        });
                });

            modelBuilder.Entity("FullStackCapstone.Models.Frequency", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Frequencies");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Daily"
                        },
                        new
                        {
                            Id = 2,
                            Description = "Weekly"
                        },
                        new
                        {
                            Id = 3,
                            Description = "Bi-Weekly"
                        },
                        new
                        {
                            Id = 4,
                            Description = "Monthly"
                        },
                        new
                        {
                            Id = 5,
                            Description = "Quarterly"
                        },
                        new
                        {
                            Id = 6,
                            Description = "Annually"
                        });
                });

            modelBuilder.Entity("FullStackCapstone.Models.Household", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("UserProfileId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("UserProfileId");

                    b.ToTable("Households");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            IsActive = true,
                            Name = "She & Her",
                            UserProfileId = 2
                        });
                });

            modelBuilder.Entity("FullStackCapstone.Models.HouseholdUser", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("HouseholdId")
                        .HasColumnType("integer");

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsAdmin")
                        .HasColumnType("boolean");

                    b.Property<int>("UserProfileId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("HouseholdId");

                    b.HasIndex("UserProfileId");

                    b.ToTable("HouseholdUsers");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            HouseholdId = 1,
                            IsActive = true,
                            IsAdmin = true,
                            UserProfileId = 2
                        },
                        new
                        {
                            Id = 2,
                            HouseholdId = 1,
                            IsActive = true,
                            IsAdmin = false,
                            UserProfileId = 3
                        });
                });

            modelBuilder.Entity("FullStackCapstone.Models.Income", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<decimal>("Amount")
                        .HasColumnType("numeric");

                    b.Property<int>("CreatedById")
                        .HasColumnType("integer");

                    b.Property<int?>("FrequencyId")
                        .HasColumnType("integer");

                    b.Property<int>("HouseholdId")
                        .HasColumnType("integer");

                    b.Property<bool>("IsFavorite")
                        .HasColumnType("boolean");

                    b.Property<bool?>("IsFrequent")
                        .HasColumnType("boolean");

                    b.Property<string>("Source")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("character varying(25)");

                    b.HasKey("Id");

                    b.HasIndex("CreatedById");

                    b.HasIndex("FrequencyId");

                    b.HasIndex("HouseholdId");

                    b.ToTable("Incomes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Amount = 0.10m,
                            CreatedById = 2,
                            HouseholdId = 1,
                            IsFavorite = false,
                            IsFrequent = false,
                            Source = "Student"
                        },
                        new
                        {
                            Id = 2,
                            Amount = 2400m,
                            CreatedById = 3,
                            FrequencyId = 3,
                            HouseholdId = 1,
                            IsFavorite = true,
                            IsFrequent = true,
                            Source = "Work"
                        });
                });

            modelBuilder.Entity("FullStackCapstone.Models.UserProfile", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .HasColumnType("text");

                    b.Property<string>("FirstName")
                        .HasColumnType("text");

                    b.Property<string>("IdentityUserId")
                        .HasColumnType("text");

                    b.Property<string>("LastName")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("IdentityUserId");

                    b.ToTable("UserProfiles");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Address = "101 Main Street",
                            FirstName = "Admina",
                            IdentityUserId = "dbc40bc6-0829-4ac5-a3ed-180f5e916a5f",
                            LastName = "Strator"
                        },
                        new
                        {
                            Id = 2,
                            Address = "123 Street Road",
                            FirstName = "MLee",
                            IdentityUserId = "someOtherUserId123456789",
                            LastName = "Law"
                        },
                        new
                        {
                            Id = 3,
                            Address = "123 Street Road",
                            FirstName = "Abigail",
                            IdentityUserId = "someOtherUserId123456788",
                            LastName = "Ezell"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex");

                    b.ToTable("AspNetRoles", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "c3aaeb97-d2ba-4a53-a521-4eea61e59b35",
                            Name = "Admin",
                            NormalizedName = "admin"
                        },
                        new
                        {
                            Id = "dfcde332-19d2-4078-8deb-72f54818bf20",
                            Name = "User",
                            NormalizedName = "USER"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("text");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("text");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("integer");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("boolean");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("boolean");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("text");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("text");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("boolean");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("text");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("boolean");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex");

                    b.ToTable("AspNetUsers", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "dbc40bc6-0829-4ac5-a3ed-180f5e916a5f",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "d2c2d1f8-9fe3-4898-85b5-8641a4f21c3d",
                            Email = "admina@strator.comx",
                            EmailConfirmed = false,
                            LockoutEnabled = false,
                            PasswordHash = "AQAAAAIAAYagAAAAEIDAKm0m17D/MqqiZMgbAzhxffQOAeUd1zxJq6I9p6b1cuADvahKbo+0IvXPhS9sxQ==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "95cc5433-f496-4171-a8c5-41fabaebdc81",
                            TwoFactorEnabled = false,
                            UserName = "Administrator"
                        },
                        new
                        {
                            Id = "someOtherUserId123456789",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "0a8c010f-85de-4899-9e65-b785bc600f09",
                            Email = "mleelaw123@gmail.com",
                            EmailConfirmed = false,
                            LockoutEnabled = false,
                            PasswordHash = "AQAAAAIAAYagAAAAED1DboNI09JqzumdFHJlZc12skediEm1NLKLMLBb77e0GlfCH3Su6nAZvlPt7aEXKg==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "f62fb1a4-c496-41d8-a14f-880b7d2d5ddd",
                            TwoFactorEnabled = false,
                            UserName = "MLee"
                        },
                        new
                        {
                            Id = "someOtherUserId123456788",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "d46dfdcc-1f3e-46c8-8877-af24fb1a1562",
                            Email = "maezell@gmail.com",
                            EmailConfirmed = false,
                            LockoutEnabled = false,
                            PasswordHash = "AQAAAAIAAYagAAAAELb45bwktVKcmDVlxv76oIntyo9RuNcgrmD6aY4VqW9fIWPTNjkxJ0qK5c8Di1irAg==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "11f01bc7-8842-4b8d-8ac0-bf8640666f72",
                            TwoFactorEnabled = false,
                            UserName = "Abigail"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("text");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("text");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("text");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("text");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("text");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("text");

                    b.Property<string>("RoleId")
                        .HasColumnType("text");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);

                    b.HasData(
                        new
                        {
                            UserId = "dbc40bc6-0829-4ac5-a3ed-180f5e916a5f",
                            RoleId = "c3aaeb97-d2ba-4a53-a521-4eea61e59b35"
                        },
                        new
                        {
                            UserId = "someOtherUserId123456789",
                            RoleId = "c3aaeb97-d2ba-4a53-a521-4eea61e59b35"
                        },
                        new
                        {
                            UserId = "someOtherUserId123456788",
                            RoleId = "dfcde332-19d2-4078-8deb-72f54818bf20"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("text");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("Value")
                        .HasColumnType("text");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("FullStackCapstone.Models.Expense", b =>
                {
                    b.HasOne("FullStackCapstone.Models.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FullStackCapstone.Models.Frequency", "Frequency")
                        .WithMany()
                        .HasForeignKey("FrequencyId");

                    b.HasOne("FullStackCapstone.Models.Household", "Household")
                        .WithMany("Expenses")
                        .HasForeignKey("HouseholdId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FullStackCapstone.Models.UserProfile", "PurchasedBy")
                        .WithMany()
                        .HasForeignKey("PurchasedByUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("Frequency");

                    b.Navigation("Household");

                    b.Navigation("PurchasedBy");
                });

            modelBuilder.Entity("FullStackCapstone.Models.Household", b =>
                {
                    b.HasOne("FullStackCapstone.Models.UserProfile", "UserProfile")
                        .WithMany()
                        .HasForeignKey("UserProfileId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("UserProfile");
                });

            modelBuilder.Entity("FullStackCapstone.Models.HouseholdUser", b =>
                {
                    b.HasOne("FullStackCapstone.Models.Household", "Household")
                        .WithMany("HouseholdUsers")
                        .HasForeignKey("HouseholdId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FullStackCapstone.Models.UserProfile", "UserProfile")
                        .WithMany("HouseholdUsers")
                        .HasForeignKey("UserProfileId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Household");

                    b.Navigation("UserProfile");
                });

            modelBuilder.Entity("FullStackCapstone.Models.Income", b =>
                {
                    b.HasOne("FullStackCapstone.Models.UserProfile", "Creator")
                        .WithMany()
                        .HasForeignKey("CreatedById")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FullStackCapstone.Models.Frequency", "Frequency")
                        .WithMany()
                        .HasForeignKey("FrequencyId");

                    b.HasOne("FullStackCapstone.Models.Household", "Household")
                        .WithMany("Incomes")
                        .HasForeignKey("HouseholdId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Creator");

                    b.Navigation("Frequency");

                    b.Navigation("Household");
                });

            modelBuilder.Entity("FullStackCapstone.Models.UserProfile", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", "IdentityUser")
                        .WithMany()
                        .HasForeignKey("IdentityUserId");

                    b.Navigation("IdentityUser");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("FullStackCapstone.Models.Household", b =>
                {
                    b.Navigation("Expenses");

                    b.Navigation("HouseholdUsers");

                    b.Navigation("Incomes");
                });

            modelBuilder.Entity("FullStackCapstone.Models.UserProfile", b =>
                {
                    b.Navigation("HouseholdUsers");
                });
#pragma warning restore 612, 618
        }
    }
}

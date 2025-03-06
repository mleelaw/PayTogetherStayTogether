using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FullStackCapstone.Migrations
{
    /// <inheritdoc />
    public partial class addedmodelsanddbcontext : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Frequencies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Description = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Frequencies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Households",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    UserProfileId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Households", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Households_UserProfiles_UserProfileId",
                        column: x => x.UserProfileId,
                        principalTable: "UserProfiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Expenses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    HouseholdId = table.Column<int>(type: "integer", nullable: false),
                    Amount = table.Column<decimal>(type: "numeric", nullable: false),
                    CategoryId = table.Column<int>(type: "integer", nullable: false),
                    Description = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    DateOfExpense = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    PurchasedByUserId = table.Column<int>(type: "integer", nullable: false),
                    PurchasedById = table.Column<int>(type: "integer", nullable: true),
                    isRecurring = table.Column<bool>(type: "boolean", nullable: true),
                    FrequencyId = table.Column<int>(type: "integer", nullable: true),
                    IsFavorite = table.Column<bool>(type: "boolean", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Expenses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Expenses_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Expenses_Frequencies_FrequencyId",
                        column: x => x.FrequencyId,
                        principalTable: "Frequencies",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Expenses_Households_HouseholdId",
                        column: x => x.HouseholdId,
                        principalTable: "Households",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Expenses_UserProfiles_PurchasedById",
                        column: x => x.PurchasedById,
                        principalTable: "UserProfiles",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "HouseholdUsers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    HouseholdId = table.Column<int>(type: "integer", nullable: false),
                    UserProfileId = table.Column<int>(type: "integer", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    IsAdmin = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HouseholdUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HouseholdUsers_Households_HouseholdId",
                        column: x => x.HouseholdId,
                        principalTable: "Households",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HouseholdUsers_UserProfiles_UserProfileId",
                        column: x => x.UserProfileId,
                        principalTable: "UserProfiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Incomes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Amount = table.Column<decimal>(type: "numeric", nullable: false),
                    Source = table.Column<string>(type: "character varying(25)", maxLength: 25, nullable: false),
                    CreatedById = table.Column<int>(type: "integer", nullable: false),
                    IsFavorite = table.Column<bool>(type: "boolean", nullable: false),
                    IsFrequent = table.Column<bool>(type: "boolean", nullable: true),
                    FrequencyId = table.Column<int>(type: "integer", nullable: true),
                    HouseholdId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Incomes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Incomes_Frequencies_FrequencyId",
                        column: x => x.FrequencyId,
                        principalTable: "Frequencies",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Incomes_Households_HouseholdId",
                        column: x => x.HouseholdId,
                        principalTable: "Households",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Incomes_UserProfiles_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "UserProfiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "dfcde332-19d2-4078-8deb-72f54818bf20", null, "User", "user" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dbc40bc6-0829-4ac5-a3ed-180f5e916a5f",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b1ced98e-149a-4515-a486-2a4c198a03df", "AQAAAAIAAYagAAAAELlU1qjHUEp/AFv7zi+UY1G91ChRfBxHp0w0F8KxXGvl44K4kIywcSM5jeRXaeMCdw==", "e5f1ac93-d911-4680-b985-50c07ddf1f8c" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "someOtherUserId123456789", 0, "85120a89-2784-455a-ba86-69295d0f7ea9", "m.lee@example.com", false, false, null, null, null, "AQAAAAIAAYagAAAAEIxXN74F9V8zod9dkXobF9Q9VHx+vzLRRWTMQDmxgTIEJhwb+9/+nIEvv/2vb0MC4A==", null, false, "0c361eb2-bd53-4b06-8838-50819bc3ed52", false, "MLee" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Rent" },
                    { 2, "Groceries" },
                    { 3, "Pet Expenses" }
                });

            migrationBuilder.InsertData(
                table: "Frequencies",
                columns: new[] { "Id", "Description" },
                values: new object[,]
                {
                    { 1, "Daily" },
                    { 2, "Weekly" },
                    { 3, "Bi-Weekly" },
                    { 4, "Monthly" },
                    { 5, "Quarterly" },
                    { 6, "Annually" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "c3aaeb97-d2ba-4a53-a521-4eea61e59b35", "someOtherUserId123456789" });

            migrationBuilder.InsertData(
                table: "UserProfiles",
                columns: new[] { "Id", "Address", "FirstName", "IdentityUserId", "LastName" },
                values: new object[] { 2, "123 Street Road", "M'Lee", "someOtherUserId123456789", "Law" });

            migrationBuilder.InsertData(
                table: "Households",
                columns: new[] { "Id", "IsActive", "Name", "UserProfileId" },
                values: new object[] { 1, true, "She & Her", 2 });

            migrationBuilder.InsertData(
                table: "Expenses",
                columns: new[] { "Id", "Amount", "CategoryId", "DateOfExpense", "Description", "FrequencyId", "HouseholdId", "IsFavorite", "PurchasedById", "PurchasedByUserId", "isRecurring" },
                values: new object[] { 1, 36.00m, 3, new DateTime(2023, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nail Trim at Belmont Animal Hospital", 5, 1, true, null, 2, true });

            migrationBuilder.InsertData(
                table: "HouseholdUsers",
                columns: new[] { "Id", "HouseholdId", "IsActive", "IsAdmin", "UserProfileId" },
                values: new object[] { 1, 1, true, true, 2 });

            migrationBuilder.InsertData(
                table: "Incomes",
                columns: new[] { "Id", "Amount", "CreatedById", "FrequencyId", "HouseholdId", "IsFavorite", "IsFrequent", "Source" },
                values: new object[] { 1, 0.10m, 2, null, 1, false, false, "Student" });

            migrationBuilder.CreateIndex(
                name: "IX_Expenses_CategoryId",
                table: "Expenses",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Expenses_FrequencyId",
                table: "Expenses",
                column: "FrequencyId");

            migrationBuilder.CreateIndex(
                name: "IX_Expenses_HouseholdId",
                table: "Expenses",
                column: "HouseholdId");

            migrationBuilder.CreateIndex(
                name: "IX_Expenses_PurchasedById",
                table: "Expenses",
                column: "PurchasedById");

            migrationBuilder.CreateIndex(
                name: "IX_Households_UserProfileId",
                table: "Households",
                column: "UserProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_HouseholdUsers_HouseholdId",
                table: "HouseholdUsers",
                column: "HouseholdId");

            migrationBuilder.CreateIndex(
                name: "IX_HouseholdUsers_UserProfileId",
                table: "HouseholdUsers",
                column: "UserProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_Incomes_CreatedById",
                table: "Incomes",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Incomes_FrequencyId",
                table: "Incomes",
                column: "FrequencyId");

            migrationBuilder.CreateIndex(
                name: "IX_Incomes_HouseholdId",
                table: "Incomes",
                column: "HouseholdId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Expenses");

            migrationBuilder.DropTable(
                name: "HouseholdUsers");

            migrationBuilder.DropTable(
                name: "Incomes");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Frequencies");

            migrationBuilder.DropTable(
                name: "Households");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "dfcde332-19d2-4078-8deb-72f54818bf20");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "c3aaeb97-d2ba-4a53-a521-4eea61e59b35", "someOtherUserId123456789" });

            migrationBuilder.DeleteData(
                table: "UserProfiles",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "someOtherUserId123456789");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dbc40bc6-0829-4ac5-a3ed-180f5e916a5f",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3e97a82b-7fac-4746-9321-6b4188aa3032", "AQAAAAIAAYagAAAAEDXpGhSrOYviPSxaQPYuPOwAMw9rmabNVe6MGZK+9DSq0Yj92ZsGpAirGYglBiLFEQ==", "fa95c23d-629b-482b-9058-1d69665f624c" });
        }
    }
}

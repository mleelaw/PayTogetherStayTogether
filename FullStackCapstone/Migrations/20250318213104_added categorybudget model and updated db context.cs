using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace FullStackCapstone.Migrations
{
    /// <inheritdoc />
    public partial class addedcategorybudgetmodelandupdateddbcontext : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CategoryBudgets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CategoryId = table.Column<int>(type: "integer", nullable: false),
                    RemainingBudget = table.Column<decimal>(type: "numeric", nullable: false),
                    Month = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryBudgets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CategoryBudgets_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dbc40bc6-0829-4ac5-a3ed-180f5e916a5f",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3b30cb9c-4952-47f4-b80c-8e69a5e4102d", "AQAAAAIAAYagAAAAEIjCQh00di7rVp/nWU3v/mlZCJxGPWADhLwSXfM0E6Z/q7B5Je0aBGHo8pdG91dOaA==", "2bbd0af4-9391-4fbc-9f0f-bf53c9967b10" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "someOtherUserId123456788",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "49e1ccb8-e7f8-4ca2-a7dd-722694eeb749", "AQAAAAIAAYagAAAAEKS+gcVXOM7iBrYKqkS0no7PLScpWiET8MWirtQSgjX8ZLrV87i/63zYu0kjT6AwgA==", "d013de5a-8a16-49e6-bbb5-5bf6d65d08f1" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "someOtherUserId123456789",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1bb17685-c423-4e04-9d49-6e1432e2ef7a", "AQAAAAIAAYagAAAAEMtm5gX1/k/Ig2guiiH1OjN3VPuT33x2A4nWMzAbU2qY6puwez3lpbOFdWoD5vXFAg==", "95584157-f00f-42ce-9b09-2828efedc4f4" });

            migrationBuilder.UpdateData(
                table: "Incomes",
                keyColumn: "Id",
                keyValue: 1,
                column: "IncomeCreatedDate",
                value: new DateTime(2025, 3, 18, 16, 31, 3, 690, DateTimeKind.Local).AddTicks(5102));

            migrationBuilder.UpdateData(
                table: "Incomes",
                keyColumn: "Id",
                keyValue: 2,
                column: "IncomeCreatedDate",
                value: new DateTime(2025, 3, 18, 16, 31, 3, 690, DateTimeKind.Local).AddTicks(5110));

            migrationBuilder.UpdateData(
                table: "Incomes",
                keyColumn: "Id",
                keyValue: 3,
                column: "IncomeCreatedDate",
                value: new DateTime(2025, 3, 18, 16, 31, 3, 690, DateTimeKind.Local).AddTicks(5115));

            migrationBuilder.CreateIndex(
                name: "IX_CategoryBudgets_CategoryId",
                table: "CategoryBudgets",
                column: "CategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CategoryBudgets");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dbc40bc6-0829-4ac5-a3ed-180f5e916a5f",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9b9665fd-f9d8-4051-b4a6-cab5e3901756", "AQAAAAIAAYagAAAAEP2f5fvVEToJ1PgR2fTxZdMf/w7nS8c9jC3yfV6lvlpM1KDsJgnoHOEWAPRU0QHkNQ==", "00b7b318-2be8-47fa-8bcb-788e191a9ae6" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "someOtherUserId123456788",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "59f28f69-cf6b-40f6-abc3-5dd394946286", "AQAAAAIAAYagAAAAEJkZdupx2Z4RwAzpeaEincgeWUA0P1KBNbrHPctfGmsW6fqiGZMOr0uq7SKf3p8P+w==", "bc08a86e-a56f-4821-b333-f917a7608e54" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "someOtherUserId123456789",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d36ba85c-23bc-411c-b4c9-1c9e4d5a309f", "AQAAAAIAAYagAAAAEPp0qnWwEAV65utV/qLOoNiI4Og2X/4280S7WcCzO5n7GWCVBzTFwfzPR/9q6JK24w==", "d0796b5c-69ca-4754-91bd-b2701e283444" });

            migrationBuilder.UpdateData(
                table: "Incomes",
                keyColumn: "Id",
                keyValue: 1,
                column: "IncomeCreatedDate",
                value: new DateTime(2025, 3, 18, 12, 5, 36, 655, DateTimeKind.Local).AddTicks(1281));

            migrationBuilder.UpdateData(
                table: "Incomes",
                keyColumn: "Id",
                keyValue: 2,
                column: "IncomeCreatedDate",
                value: new DateTime(2025, 3, 18, 12, 5, 36, 655, DateTimeKind.Local).AddTicks(1306));

            migrationBuilder.UpdateData(
                table: "Incomes",
                keyColumn: "Id",
                keyValue: 3,
                column: "IncomeCreatedDate",
                value: new DateTime(2025, 3, 18, 12, 5, 36, 655, DateTimeKind.Local).AddTicks(1318));
        }
    }
}

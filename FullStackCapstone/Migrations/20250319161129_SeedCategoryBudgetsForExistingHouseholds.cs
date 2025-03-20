using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FullStackCapstone.Migrations
{
    /// <inheritdoc />
    public partial class SeedCategoryBudgetsForExistingHouseholds : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            {
                migrationBuilder.Sql(@"
        -- Insert CategoryBudgets for all existing households and each category
        INSERT INTO ""CategoryBudgets"" (""CategoryId"", ""HouseholdId"", ""RemainingBudget"", ""Month"")
        SELECT 
            c.""Id"", 
            h.""Id"", 
            COALESCE(c.""CategoryBudgetForTheMonth"", 0), -- Set the initial budget
            DATE_TRUNC('month', NOW()) -- Set to current month
        FROM ""Households"" h
        CROSS JOIN ""Categories"" c
        WHERE NOT EXISTS (
            SELECT 1 
            FROM ""CategoryBudgets"" cb
            WHERE cb.""HouseholdId"" = h.""Id"" 
            AND cb.""CategoryId"" = c.""Id""
            AND DATE_TRUNC('month', cb.""Month"") = DATE_TRUNC('month', NOW())
        )
    ");
            }

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dbc40bc6-0829-4ac5-a3ed-180f5e916a5f",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6e8c1645-21a9-4c7b-8168-e3cd8624a3ba", "AQAAAAIAAYagAAAAEJWn1iNbUSwn3PQtVq7crABrIG/88eh2lsNFGc9Pdtj+cOGAbierhWUuiOZ2elth0w==", "dfa7f6ab-8988-41f2-8232-572850b44921" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "someOtherUserId123456788",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e3560697-02d3-463a-adca-62a44c077e2b", "AQAAAAIAAYagAAAAEOTE7vhMbDNVOsetzH9wEbpWjMIrQzx3muWSlcHr/aGPbOx7qMFsvGz0Zijnqn4WXQ==", "d513feb9-b115-4780-926a-258dffed5e70" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "someOtherUserId123456789",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f21e658f-4cb9-4d90-bec0-0a05f268a064", "AQAAAAIAAYagAAAAEJnwsSZCIFu9tzZLsPwvztNmuqcSC+YiZg+ciZMPeHE+A3778MT3n+88BBwA7A/tNw==", "66212473-7aa0-4c93-be13-902cd49cc9a3" });

            migrationBuilder.UpdateData(
                table: "Incomes",
                keyColumn: "Id",
                keyValue: 1,
                column: "IncomeCreatedDate",
                value: new DateTime(2025, 3, 19, 11, 11, 28, 993, DateTimeKind.Local).AddTicks(5716));

            migrationBuilder.UpdateData(
                table: "Incomes",
                keyColumn: "Id",
                keyValue: 2,
                column: "IncomeCreatedDate",
                value: new DateTime(2025, 3, 19, 11, 11, 28, 993, DateTimeKind.Local).AddTicks(5748));

            migrationBuilder.UpdateData(
                table: "Incomes",
                keyColumn: "Id",
                keyValue: 3,
                column: "IncomeCreatedDate",
                value: new DateTime(2025, 3, 19, 11, 11, 28, 993, DateTimeKind.Local).AddTicks(5753));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dbc40bc6-0829-4ac5-a3ed-180f5e916a5f",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9c2599ab-aa08-49a7-9bac-679120b5120c", "AQAAAAIAAYagAAAAEGsYs1stg5q+jDed66716MqWzqSILX3Vy3tzU+jeRATDDKINqsU1ySUsktFH3o342Q==", "4d09aa37-086d-4587-bc62-b87ae45b7839" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "someOtherUserId123456788",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6630f815-9aba-47e2-84fd-49d677d1c648", "AQAAAAIAAYagAAAAEO38mx1c503ETDFHPOQmklDGGvM4Q0KSuJVajQsTa2wui3gF/isugMCWnCmbfMyBuA==", "2808d069-e13b-4065-a7e9-3215ee287227" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "someOtherUserId123456789",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "026a12ab-f10a-4c92-ae54-f91fb4b33667", "AQAAAAIAAYagAAAAEJsUuS+pa5SxjPQvuBa3OJk95bNPoW1s93P0YKQ+K4eUHl5sEXnfBKFdfm4Q76uJxQ==", "56076210-4502-4e9c-8cb5-12770a3a1ecc" });

            migrationBuilder.UpdateData(
                table: "Incomes",
                keyColumn: "Id",
                keyValue: 1,
                column: "IncomeCreatedDate",
                value: new DateTime(2025, 3, 19, 10, 25, 53, 147, DateTimeKind.Local).AddTicks(4410));

            migrationBuilder.UpdateData(
                table: "Incomes",
                keyColumn: "Id",
                keyValue: 2,
                column: "IncomeCreatedDate",
                value: new DateTime(2025, 3, 19, 10, 25, 53, 147, DateTimeKind.Local).AddTicks(4415));

            migrationBuilder.UpdateData(
                table: "Incomes",
                keyColumn: "Id",
                keyValue: 3,
                column: "IncomeCreatedDate",
                value: new DateTime(2025, 3, 19, 10, 25, 53, 147, DateTimeKind.Local).AddTicks(4417));
        }
    }
}

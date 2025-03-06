using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FullStackCapstone.Migrations
{
    /// <inheritdoc />
    public partial class addedexpenseconrollerandDTOs : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "CategoryBudgetForTheMonth",
                table: "Categories",
                type: "numeric",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Categories",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dbc40bc6-0829-4ac5-a3ed-180f5e916a5f",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f1e8b99f-54f9-46b9-8f50-a1ea90725907", "AQAAAAIAAYagAAAAEL3ePew/jUbtNrjwZ0QgCKp74vck9zUWmq/+/cIlbBscOLdS8qwJUFLpIjgFgFwRXQ==", "99b9b74e-9e8c-4683-b928-e0e1b66227aa" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "someOtherUserId123456789",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "02f20131-e954-4048-a822-b36dcc3ef1d4", "AQAAAAIAAYagAAAAEGqUjf+crceEFAVXzJLH3m62UkVrSVOcXXvzI93LMXPlsf7XN5I79frQnHa0U5AN1w==", "e8c623ea-3f29-4579-a2f2-bff4b4d77970" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CategoryBudgetForTheMonth", "IsActive" },
                values: new object[] { 2000.00m, true });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CategoryBudgetForTheMonth", "IsActive" },
                values: new object[] { 1000.00m, true });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CategoryBudgetForTheMonth", "IsActive" },
                values: new object[] { 150.00m, true });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CategoryBudgetForTheMonth",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Categories");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dbc40bc6-0829-4ac5-a3ed-180f5e916a5f",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b260050e-d6f3-4cc0-b36a-6d436bc5e2c9", "AQAAAAIAAYagAAAAEH4ZTyoXlHOr7XaP0SXTZ74HHhB0RmFQNThyTsgBVg402HIT8tigWDKUeai133zbsw==", "1735c309-17cc-437c-9655-bf0d2049c1f0" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "someOtherUserId123456789",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "48218683-c3a8-4033-a1e4-c56fc3cf9627", "AQAAAAIAAYagAAAAEG/48n31gdUpxs6XSxIpsj9HOVayWJ8qDVFUeDq2okXoxbs9UrwUIKlRyP+uOyeN4g==", "f42ea9a1-68e2-4c50-9eea-1f597c45d394" });
        }
    }
}

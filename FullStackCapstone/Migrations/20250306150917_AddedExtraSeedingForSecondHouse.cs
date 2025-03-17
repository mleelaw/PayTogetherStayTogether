using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FullStackCapstone.Migrations
{
    /// <inheritdoc />
    public partial class AddedExtraSeedingForSecondHouse : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dbc40bc6-0829-4ac5-a3ed-180f5e916a5f",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "89afc56b-24ff-4315-846a-cfea1a525c17", "AQAAAAIAAYagAAAAEB3xSSo694mNwMuESegDxN8YiUiDj7BXbF3/oIqp2RgHfnU+oZtBN/shmljGQ8Px2w==", "64a0909b-5b11-41e4-9d0b-1feebf2b48dd" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "someOtherUserId123456788",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1563be4e-ae91-4b7e-91e7-4e063ccd781e", "AQAAAAIAAYagAAAAEDYCXXTyJ8glgTXKUMfVLIYNDIKBf3xqms1LJtHFZtuBM/eH5Dvp0NBGNFMJ55k4hw==", "a441e1ca-d0af-4382-a24d-ee2f41c86d2b" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "someOtherUserId123456789",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "cefe474a-3fae-44d2-a0ad-71e91c256afb", "AQAAAAIAAYagAAAAEMZqhELtZcpfvMWaz7z30fqDXtzm3ZCDkEdPF4bdfDe7QpyQ3si29+gNc+/TC7rw/A==", "86697625-b900-4e72-a5c8-9c286e50e573" });

            migrationBuilder.InsertData(
                table: "Households",
                columns: new[] { "Id", "IsActive", "Name", "UserProfileId" },
                values: new object[] { 2, true, "My Other Family", 1 });

            migrationBuilder.InsertData(
                table: "Expenses",
                columns: new[] { "Id", "Amount", "CategoryId", "DateOfExpense", "Description", "FrequencyId", "HouseholdId", "IsFavorite", "IsRecurring", "PurchasedByUserId" },
                values: new object[] { 4, 1900m, 1, new DateTime(2023, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Rent", 4, 2, true, true, 1 });

            migrationBuilder.InsertData(
                table: "HouseholdUsers",
                columns: new[] { "Id", "HouseholdId", "IsActive", "IsAdmin", "UserProfileId" },
                values: new object[] { 3, 2, true, false, 1 });

            migrationBuilder.InsertData(
                table: "Incomes",
                columns: new[] { "Id", "Amount", "CreatedById", "FrequencyId", "HouseholdId", "IsFavorite", "IsFrequent", "Source" },
                values: new object[] { 3, 2400m, 1, 3, 2, true, true, "Work" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Expenses",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "HouseholdUsers",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Incomes",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Households",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dbc40bc6-0829-4ac5-a3ed-180f5e916a5f",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "af98ee58-f94d-4519-9a34-3e1318b122c0", "AQAAAAIAAYagAAAAEPAqr4vK8J+l4Cd5AqHR/wVa/aRFYdP/7Al39o0TSzYfCL1WqPsI3HhCWSI7xgiyBw==", "5772659b-2865-42f0-bb4c-be85cbbc3aed" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "someOtherUserId123456788",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ae7e1172-06b7-431f-b6b7-70a02c8b90a2", "AQAAAAIAAYagAAAAEBrqw/U+d+OmxIiz3X6mbVrpBnrtURlZWokVvEswU1+ntOQ4yJLRaW4EnverRipMaQ==", "cf250651-ccef-4f20-acda-5ac335aa95dc" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "someOtherUserId123456789",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e8ca3922-dc8d-4560-bec3-96c13b67aa3e", "AQAAAAIAAYagAAAAEGllkz0FqJDKIs3BQlUUmFZ2tjuby+CJu5KuekKpB7yjBVB4M9iX4geLUz5zRUxbLA==", "3d304756-dcce-4a0c-a0a0-01ac4b051c32" });
        }
    }
}

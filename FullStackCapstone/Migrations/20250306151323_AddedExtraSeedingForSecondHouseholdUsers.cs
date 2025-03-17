using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FullStackCapstone.Migrations
{
    /// <inheritdoc />
    public partial class AddedExtraSeedingForSecondHouseholdUsers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dbc40bc6-0829-4ac5-a3ed-180f5e916a5f",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b2e40167-c410-485c-98d4-c7d49ba3c539", "AQAAAAIAAYagAAAAEHJG+yt7MwO3c3dONmpKG4daoeN0kY0uXaoQeiKwzxi5u2nbASKroNrpULXAMETnIQ==", "1d661c7e-cb24-4766-95a6-4b3629066e6e" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "someOtherUserId123456788",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4366e6c7-b82f-49f4-a247-806343d65c3c", "AQAAAAIAAYagAAAAEJVojC4gRXNNyIbNbfomwMXAiH7acL1BfgzLwVEghKlrBwqoqXg8YIR+U8WHqj28Cw==", "52b79e0c-ff02-44a8-ab84-2cfcb791cff5" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "someOtherUserId123456789",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9271c63d-1de1-46af-b0ad-0054db241f43", "AQAAAAIAAYagAAAAEOEqvMk59zhhaxFyJobgKUAZAi3RKP7ZAXORWDgpSKFD/VDdrBvOl+9iLL9ZcqBpLw==", "bfee9c51-b211-4038-ad51-2a6208e2757a" });

            migrationBuilder.InsertData(
                table: "HouseholdUsers",
                columns: new[] { "Id", "HouseholdId", "IsActive", "IsAdmin", "UserProfileId" },
                values: new object[] { 4, 1, true, false, 3 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "HouseholdUsers",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dbc40bc6-0829-4ac5-a3ed-180f5e916a5f",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d6cf8749-a053-4d02-bd8d-64fb0a6f3071", "AQAAAAIAAYagAAAAEIFTjg/5MX6AZYz9kdmzAIbdoUXn3xJ52CcUYfoe5HS3s0W5nBb5gilSL+se6sepDw==", "f4eee73b-247c-40ed-b1ef-eec23bf70098" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "someOtherUserId123456788",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c1923067-08aa-4f66-9250-6f265e893aeb", "AQAAAAIAAYagAAAAEH+VXml3xcRclu4kYsj4OxeF0YqTi9knF9tz3M5Z6LZ1buZLvpOizVpWAaTz/GDnHA==", "3bfc328d-a40b-4f0e-bb31-3aa0396150f0" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "someOtherUserId123456789",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b1606a49-0fa7-4b8e-b4b5-dd26f3c44bd6", "AQAAAAIAAYagAAAAEPSUb0wmUS8TKbFqjgsVZxQrlyvTHRM9iHvhZxM7cq2lWPlVwS8k9LETq7IrrLKeqg==", "d2e775dd-658a-49d1-85f1-2bf929b51f8a" });
        }
    }
}

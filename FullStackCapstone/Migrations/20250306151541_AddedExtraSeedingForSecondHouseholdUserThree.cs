using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FullStackCapstone.Migrations
{
    /// <inheritdoc />
    public partial class AddedExtraSeedingForSecondHouseholdUserThree : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dbc40bc6-0829-4ac5-a3ed-180f5e916a5f",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "731e0955-3f37-4293-b082-3353fca9022c", "AQAAAAIAAYagAAAAEKnThfbE1/5rACZWT3R05ZM77BREU+c6i06cl+S6nFZymzCvnn/o5IRNHN+4mCxSsg==", "0f45ea7e-b042-4b7c-a2b7-9c6b68c147e6" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "someOtherUserId123456788",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "224d384d-8873-47a2-a5f2-0799acafeb0a", "AQAAAAIAAYagAAAAEIPKJQL0GGzeA81y1YJFSuFW/FyoVxyrsc9GPyxSfJ6pC9EKJEct1OCs9FyZd/IJog==", "01b2fdd0-57b5-4533-b02a-f230b33e7443" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "someOtherUserId123456789",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a95e6a07-cad9-4d4c-af7c-64a35bef3fc4", "AQAAAAIAAYagAAAAEGe7vlY7KGnMn64ORD264juz4uGMJmUSgxsE3h7p1ZH9n6+Vr8cmNBGs2IyCLW1iVw==", "1eafd3ce-5689-431e-838a-b65b1936aa73" });

            migrationBuilder.UpdateData(
                table: "HouseholdUsers",
                keyColumn: "Id",
                keyValue: 4,
                column: "HouseholdId",
                value: 2);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.UpdateData(
                table: "HouseholdUsers",
                keyColumn: "Id",
                keyValue: 4,
                column: "HouseholdId",
                value: 1);
        }
    }
}

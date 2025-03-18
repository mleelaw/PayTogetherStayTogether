using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FullStackCapstone.Migrations
{
    /// <inheritdoc />
    public partial class AddIncomecreatedDate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "IncomeCreatedDate",
                table: "Incomes",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IncomeCreatedDate",
                table: "Incomes");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dbc40bc6-0829-4ac5-a3ed-180f5e916a5f",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1762790c-cb64-4363-8f84-eb24bd4bba58", "AQAAAAIAAYagAAAAEA23hN6nDjA+ojHk0hBSdjpX3pOSbBqp3xZ2JqCZy/gVuEDZyMa0LEP5XAHrbkMbkg==", "97ef510c-3deb-4223-8262-218103383beb" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "someOtherUserId123456788",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6b85e992-f247-493f-9693-4286977f3f12", "AQAAAAIAAYagAAAAEJgUKgPTwSjoPwt3Y7TbFZjCa+Xy9vri+QZ5gtxMDOLbmUnhR0QZx1tkLoTg092eIw==", "e0b2862a-a939-41c8-bb64-ffa812f997d4" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "someOtherUserId123456789",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e80c78d8-69e6-4bd4-9de5-e837846f904c", "AQAAAAIAAYagAAAAEHTFRJVqW8u/dFQwdjtgQo+iO9Hw2kuO7EBJuG2Pp6d9y+1RcU5iuDdCAKdql22ouQ==", "757c4524-cf71-4e52-9b61-04b422c8a39f" });
        }
    }
}

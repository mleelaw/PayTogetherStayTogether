using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FullStackCapstone.Migrations
{
    /// <inheritdoc />
    public partial class addedhouseholdIdtocategorybudgetmodel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "HouseholdId",
                table: "CategoryBudgets",
                type: "integer",
                nullable: false,
                defaultValue: 0);

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HouseholdId",
                table: "CategoryBudgets");

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
        }
    }
}

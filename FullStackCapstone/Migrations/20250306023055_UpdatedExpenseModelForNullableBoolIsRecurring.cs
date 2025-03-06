using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FullStackCapstone.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedExpenseModelForNullableBoolIsRecurring : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "IsRecurring",
                table: "Expenses",
                type: "boolean",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "boolean",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dbc40bc6-0829-4ac5-a3ed-180f5e916a5f",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d2c2d1f8-9fe3-4898-85b5-8641a4f21c3d", "AQAAAAIAAYagAAAAEIDAKm0m17D/MqqiZMgbAzhxffQOAeUd1zxJq6I9p6b1cuADvahKbo+0IvXPhS9sxQ==", "95cc5433-f496-4171-a8c5-41fabaebdc81" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "someOtherUserId123456788",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d46dfdcc-1f3e-46c8-8877-af24fb1a1562", "AQAAAAIAAYagAAAAELb45bwktVKcmDVlxv76oIntyo9RuNcgrmD6aY4VqW9fIWPTNjkxJ0qK5c8Di1irAg==", "11f01bc7-8842-4b8d-8ac0-bf8640666f72" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "someOtherUserId123456789",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0a8c010f-85de-4899-9e65-b785bc600f09", "AQAAAAIAAYagAAAAED1DboNI09JqzumdFHJlZc12skediEm1NLKLMLBb77e0GlfCH3Su6nAZvlPt7aEXKg==", "f62fb1a4-c496-41d8-a14f-880b7d2d5ddd" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "IsRecurring",
                table: "Expenses",
                type: "boolean",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "boolean");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dbc40bc6-0829-4ac5-a3ed-180f5e916a5f",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8f04bf87-b9d2-4734-94d4-35a6be3e5867", "AQAAAAIAAYagAAAAEOz3Ye/RpiA4Frxn11ftL+PjEhVghEvjMd2xloDZy1nl9HJl2LKoiAam6WUHRbFECw==", "e7f4c3ba-4a2b-4bfe-b8ff-86b9a503de18" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "someOtherUserId123456788",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "71a9cfee-6642-4c73-aec7-5bd7f6fc5c44", "AQAAAAIAAYagAAAAEL645wTWntaJA6qUxhbwpjOYm3GlKpZdex6/g44nolt2b2Z6elLW5y8QrsyNwcF6Bg==", "2a9435e0-b271-4f55-b9a8-8f6b4957e074" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "someOtherUserId123456789",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "efe7cec5-1411-4cfb-951a-97cec061d4fa", "AQAAAAIAAYagAAAAEHv2RNPiAMhGfjPZ3z25l6oT/LdH7BoROG52hUpyJsEuq2bM2MKQ09vDQZopB+jjfQ==", "18c52a98-59de-4c5d-90ed-2319e066b14b" });
        }
    }
}

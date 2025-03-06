using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FullStackCapstone.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedExpenseModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Expenses_UserProfiles_PurchasedById",
                table: "Expenses");

            migrationBuilder.DropIndex(
                name: "IX_Expenses_PurchasedById",
                table: "Expenses");

            migrationBuilder.DropColumn(
                name: "PurchasedById",
                table: "Expenses");

            migrationBuilder.RenameColumn(
                name: "isRecurring",
                table: "Expenses",
                newName: "IsRecurring");

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

            migrationBuilder.CreateIndex(
                name: "IX_Expenses_PurchasedByUserId",
                table: "Expenses",
                column: "PurchasedByUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Expenses_UserProfiles_PurchasedByUserId",
                table: "Expenses",
                column: "PurchasedByUserId",
                principalTable: "UserProfiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Expenses_UserProfiles_PurchasedByUserId",
                table: "Expenses");

            migrationBuilder.DropIndex(
                name: "IX_Expenses_PurchasedByUserId",
                table: "Expenses");

            migrationBuilder.RenameColumn(
                name: "IsRecurring",
                table: "Expenses",
                newName: "isRecurring");

            migrationBuilder.AddColumn<int>(
                name: "PurchasedById",
                table: "Expenses",
                type: "integer",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dbc40bc6-0829-4ac5-a3ed-180f5e916a5f",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ceadb0d6-7413-42e7-a2bf-d163418c92b4", "AQAAAAIAAYagAAAAEIT4yxg6+ZLvqsR4fwKDlk5RCY0qqMDPK0rqMPvU5SKIZzYbIacyFOfzkXcowBOJZQ==", "ec040a92-c304-4d8e-beb5-1a772b2dca21" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "someOtherUserId123456788",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7d659e56-a496-44c9-a0c8-237486b28968", "AQAAAAIAAYagAAAAEPHlEL/q64U/WBfKafMVc4gg6Qlh47hg8OCdr7iWS/NQH20ZIAvUMGIerg7yLHC1Rg==", "68e6b71e-6ac2-40b7-8aa5-878910517ba3" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "someOtherUserId123456789",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6da0a170-7372-4a95-9e57-6c570f2a75b0", "AQAAAAIAAYagAAAAEG6C4x6WupbWKhP9WETwtgJaJUlEF1IJ6gzDbDal+9j2dI595m4ynh7AOfN5QYeYBw==", "237d30ce-3686-4fff-a2b7-96222c4b0d5f" });

            migrationBuilder.UpdateData(
                table: "Expenses",
                keyColumn: "Id",
                keyValue: 1,
                column: "PurchasedById",
                value: null);

            migrationBuilder.UpdateData(
                table: "Expenses",
                keyColumn: "Id",
                keyValue: 2,
                column: "PurchasedById",
                value: null);

            migrationBuilder.UpdateData(
                table: "Expenses",
                keyColumn: "Id",
                keyValue: 3,
                column: "PurchasedById",
                value: null);

            migrationBuilder.CreateIndex(
                name: "IX_Expenses_PurchasedById",
                table: "Expenses",
                column: "PurchasedById");

            migrationBuilder.AddForeignKey(
                name: "FK_Expenses_UserProfiles_PurchasedById",
                table: "Expenses",
                column: "PurchasedById",
                principalTable: "UserProfiles",
                principalColumn: "Id");
        }
    }
}

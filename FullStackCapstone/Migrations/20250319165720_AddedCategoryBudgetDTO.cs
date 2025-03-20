using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FullStackCapstone.Migrations
{
    /// <inheritdoc />
    public partial class AddedCategoryBudgetDTO : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dbc40bc6-0829-4ac5-a3ed-180f5e916a5f",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "91ab10b8-5b06-443b-b165-e34b92cb88ae", "AQAAAAIAAYagAAAAEBRVOU6Oq1rX35QdWsPlS8VZoNZeqnVP46Hb9RJkpwX54r4j9/2FSG20DGfS81hgNA==", "2f38fd2e-799c-4067-ad59-65a6dc07ca9b" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "someOtherUserId123456788",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c53f0222-4377-4829-bea1-be2e3f570c6d", "AQAAAAIAAYagAAAAEGWFmYWmBG4fUkK0p+JpI+PBSgm3mGGLcCvForzY/7n/MVvz9Sazyl1jKMTlIL4f9g==", "dacaea70-a32f-48a8-b079-ba94091e71ed" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "someOtherUserId123456789",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c524c29f-e87d-46a8-9671-6df78e414796", "AQAAAAIAAYagAAAAEKuf8UyOZDozuvpp/HAsjwN+uZDGcOauP/ptnpK3w4daoHmPES7unZEOrLOeNOMoIg==", "1b779016-32b7-49e6-ba51-eea5e397e23b" });

            migrationBuilder.UpdateData(
                table: "Incomes",
                keyColumn: "Id",
                keyValue: 1,
                column: "IncomeCreatedDate",
                value: new DateTime(2025, 3, 19, 11, 57, 19, 790, DateTimeKind.Local).AddTicks(8452));

            migrationBuilder.UpdateData(
                table: "Incomes",
                keyColumn: "Id",
                keyValue: 2,
                column: "IncomeCreatedDate",
                value: new DateTime(2025, 3, 19, 11, 57, 19, 790, DateTimeKind.Local).AddTicks(8461));

            migrationBuilder.UpdateData(
                table: "Incomes",
                keyColumn: "Id",
                keyValue: 3,
                column: "IncomeCreatedDate",
                value: new DateTime(2025, 3, 19, 11, 57, 19, 790, DateTimeKind.Local).AddTicks(8466));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
    }
}

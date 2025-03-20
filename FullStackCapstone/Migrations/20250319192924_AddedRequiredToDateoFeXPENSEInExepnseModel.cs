using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FullStackCapstone.Migrations
{
    /// <inheritdoc />
    public partial class AddedRequiredToDateoFeXPENSEInExepnseModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dbc40bc6-0829-4ac5-a3ed-180f5e916a5f",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "98112334-a214-491b-86d3-b65ac312fb1a", "AQAAAAIAAYagAAAAEHtehsUqaCEZASRYyzTE2hwSqSjlt7znU4qALDugQAu3/HyAiZtCc91SSYsd0fycBQ==", "ac941f91-e8cd-4c5d-b9da-945984e1f2da" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "someOtherUserId123456788",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "dd3f7143-960c-48d8-87b4-0090c413d0eb", "AQAAAAIAAYagAAAAELMa3P7BCRVbSrpg/krtQt+K1Att4tPNJNQ7Gf1Gfe0i/dWDJSAZlf+cueHMyA3KIw==", "3f478912-11c9-4f02-bd4c-d103d52e858c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "someOtherUserId123456789",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e8fe3d0e-c5df-4c73-be5e-6c60f8ee130e", "AQAAAAIAAYagAAAAEGC0dPphqZwbrEtakGnRNYFHbUIACoA12JgIgSRaoFSK1qogsfEkA9/sVKkC++r/tg==", "000adfcc-96cb-4ac2-9fef-ef4299e56440" });

            migrationBuilder.UpdateData(
                table: "Incomes",
                keyColumn: "Id",
                keyValue: 1,
                column: "IncomeCreatedDate",
                value: new DateTime(2025, 3, 19, 14, 29, 23, 467, DateTimeKind.Local).AddTicks(3432));

            migrationBuilder.UpdateData(
                table: "Incomes",
                keyColumn: "Id",
                keyValue: 2,
                column: "IncomeCreatedDate",
                value: new DateTime(2025, 3, 19, 14, 29, 23, 467, DateTimeKind.Local).AddTicks(3441));

            migrationBuilder.UpdateData(
                table: "Incomes",
                keyColumn: "Id",
                keyValue: 3,
                column: "IncomeCreatedDate",
                value: new DateTime(2025, 3, 19, 14, 29, 23, 467, DateTimeKind.Local).AddTicks(3446));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
    }
}

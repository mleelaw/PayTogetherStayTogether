using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FullStackCapstone.Migrations
{
    /// <inheritdoc />
    public partial class addedmodelsanddbcontextseeddata : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dbc40bc6-0829-4ac5-a3ed-180f5e916a5f",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b5aaf4f3-f4f8-472c-9ace-065af9fbb2ce", "AQAAAAIAAYagAAAAEDA+gshiSUuOH36zjS+mRzxSktE0f40tfGBHjjuxJTlGU2k7Dw8KZeGEcSwaiYpbUg==", "4127be74-e1d0-4a4c-bd6b-20a362a646fe" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "someOtherUserId123456789",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d20ea640-25d1-437b-a7b8-0df67f7450df", "AQAAAAIAAYagAAAAEBPgd9BbOQ/qa07Zu7K1q18G7XfzY4xGMRjD3M0vgI2VQDcISjmEfADXI5d4UMEEFg==", "b39aac0a-e184-4802-9206-fd488536ff7c" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dbc40bc6-0829-4ac5-a3ed-180f5e916a5f",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1c90e922-7440-483f-b73d-303fea646bf7", "AQAAAAIAAYagAAAAEHd0zUNd+nO1DDlDaq1fqnIfpJgHR1NoqvW36Hm2PS6jo6qSU+7/45pK081fMlC1MQ==", "4f7012c9-1d9a-4788-a67a-1b3ada470a4d" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "someOtherUserId123456789",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "782834e5-168a-4699-8a84-e530b6591e9f", "AQAAAAIAAYagAAAAEI57B2PlvGX7bGX7R9RvX/Ed2PdkMGM8pKsFGNoxaU8H/KeGIljAw36+x5nKzp9R/w==", "91a14132-0668-4f5a-8d3e-171e4b262fc9" });
        }
    }
}

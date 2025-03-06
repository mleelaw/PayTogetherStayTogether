using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FullStackCapstone.Migrations
{
    /// <inheritdoc />
    public partial class addedmodelsanddbcontextdtosnotcreatedyet : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                columns: new[] { "ConcurrencyStamp", "Email", "PasswordHash", "SecurityStamp" },
                values: new object[] { "782834e5-168a-4699-8a84-e530b6591e9f", "mleelaw123@gmail.com", "AQAAAAIAAYagAAAAEI57B2PlvGX7bGX7R9RvX/Ed2PdkMGM8pKsFGNoxaU8H/KeGIljAw36+x5nKzp9R/w==", "91a14132-0668-4f5a-8d3e-171e4b262fc9" });

            migrationBuilder.UpdateData(
                table: "UserProfiles",
                keyColumn: "Id",
                keyValue: 2,
                column: "FirstName",
                value: "MLee");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dbc40bc6-0829-4ac5-a3ed-180f5e916a5f",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b1ced98e-149a-4515-a486-2a4c198a03df", "AQAAAAIAAYagAAAAELlU1qjHUEp/AFv7zi+UY1G91ChRfBxHp0w0F8KxXGvl44K4kIywcSM5jeRXaeMCdw==", "e5f1ac93-d911-4680-b985-50c07ddf1f8c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "someOtherUserId123456789",
                columns: new[] { "ConcurrencyStamp", "Email", "PasswordHash", "SecurityStamp" },
                values: new object[] { "85120a89-2784-455a-ba86-69295d0f7ea9", "m.lee@example.com", "AQAAAAIAAYagAAAAEIxXN74F9V8zod9dkXobF9Q9VHx+vzLRRWTMQDmxgTIEJhwb+9/+nIEvv/2vb0MC4A==", "0c361eb2-bd53-4b06-8838-50819bc3ed52" });

            migrationBuilder.UpdateData(
                table: "UserProfiles",
                keyColumn: "Id",
                keyValue: 2,
                column: "FirstName",
                value: "M'Lee");
        }
    }
}

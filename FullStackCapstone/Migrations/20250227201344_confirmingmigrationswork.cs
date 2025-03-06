using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FullStackCapstone.Migrations
{
    /// <inheritdoc />
    public partial class confirmingmigrationswork : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dbc40bc6-0829-4ac5-a3ed-180f5e916a5f",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3e97a82b-7fac-4746-9321-6b4188aa3032", "AQAAAAIAAYagAAAAEDXpGhSrOYviPSxaQPYuPOwAMw9rmabNVe6MGZK+9DSq0Yj92ZsGpAirGYglBiLFEQ==", "fa95c23d-629b-482b-9058-1d69665f624c" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dbc40bc6-0829-4ac5-a3ed-180f5e916a5f",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0619da13-9194-474d-8d20-76a5d8a1cafb", "AQAAAAIAAYagAAAAEMymYw9Gsoc4YACLuKF+VcvWaOB64y/8xmdfeeQqoXdnuj+0LnTRXKRcLuUYd8iLSg==", "f9221097-d617-4089-a309-c8788513232b" });
        }
    }
}

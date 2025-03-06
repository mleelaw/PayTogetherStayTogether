using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FullStackCapstone.Migrations
{
    /// <inheritdoc />
    public partial class AddedDTOforUpdatingAcategory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dbc40bc6-0829-4ac5-a3ed-180f5e916a5f",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "af98ee58-f94d-4519-9a34-3e1318b122c0", "AQAAAAIAAYagAAAAEPAqr4vK8J+l4Cd5AqHR/wVa/aRFYdP/7Al39o0TSzYfCL1WqPsI3HhCWSI7xgiyBw==", "5772659b-2865-42f0-bb4c-be85cbbc3aed" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "someOtherUserId123456788",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ae7e1172-06b7-431f-b6b7-70a02c8b90a2", "AQAAAAIAAYagAAAAEBrqw/U+d+OmxIiz3X6mbVrpBnrtURlZWokVvEswU1+ntOQ4yJLRaW4EnverRipMaQ==", "cf250651-ccef-4f20-acda-5ac335aa95dc" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "someOtherUserId123456789",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e8ca3922-dc8d-4560-bec3-96c13b67aa3e", "AQAAAAIAAYagAAAAEGllkz0FqJDKIs3BQlUUmFZ2tjuby+CJu5KuekKpB7yjBVB4M9iX4geLUz5zRUxbLA==", "3d304756-dcce-4a0c-a0a0-01ac4b051c32" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dbc40bc6-0829-4ac5-a3ed-180f5e916a5f",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ca2991f0-e8f0-482f-b0e0-d9fe770a6bab", "AQAAAAIAAYagAAAAEPygtikOW1zPPN1kXKxAbJZf/nmjri0A/k+Opy/GiFcQ4pGVXUAqxI3qRw4G2FQi0g==", "3ff516a0-10f1-48a0-b6ef-3c4fc76d5c7a" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "someOtherUserId123456788",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "330b5f2d-cd63-4b38-8585-b0625b10e0eb", "AQAAAAIAAYagAAAAEJ2WHxc502kpzZSrIHJiQm1EECwmrrYf83Od03ONuIX08ZJRXeheYOkMfchHvS5RRQ==", "27d3468d-9248-48c4-b880-0b5a153a2130" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "someOtherUserId123456789",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "626ee46b-2de9-465e-98d9-85802b5bdebe", "AQAAAAIAAYagAAAAEMLYoDucKc9QmPArIRrPMK0IMLRgBOdpIBKaaCCaKOwZ23KlSx3XDHfxrLXAZigRtw==", "8b4e8391-642a-4535-b147-0a66171c758b" });
        }
    }
}

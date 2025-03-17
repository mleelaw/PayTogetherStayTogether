using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FullStackCapstone.Migrations
{
    /// <inheritdoc />
    public partial class AddedExtraSeedingForSecondHousehold : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dbc40bc6-0829-4ac5-a3ed-180f5e916a5f",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d6cf8749-a053-4d02-bd8d-64fb0a6f3071", "AQAAAAIAAYagAAAAEIFTjg/5MX6AZYz9kdmzAIbdoUXn3xJ52CcUYfoe5HS3s0W5nBb5gilSL+se6sepDw==", "f4eee73b-247c-40ed-b1ef-eec23bf70098" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "someOtherUserId123456788",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c1923067-08aa-4f66-9250-6f265e893aeb", "AQAAAAIAAYagAAAAEH+VXml3xcRclu4kYsj4OxeF0YqTi9knF9tz3M5Z6LZ1buZLvpOizVpWAaTz/GDnHA==", "3bfc328d-a40b-4f0e-bb31-3aa0396150f0" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "someOtherUserId123456789",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b1606a49-0fa7-4b8e-b4b5-dd26f3c44bd6", "AQAAAAIAAYagAAAAEPSUb0wmUS8TKbFqjgsVZxQrlyvTHRM9iHvhZxM7cq2lWPlVwS8k9LETq7IrrLKeqg==", "d2e775dd-658a-49d1-85f1-2bf929b51f8a" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dbc40bc6-0829-4ac5-a3ed-180f5e916a5f",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "89afc56b-24ff-4315-846a-cfea1a525c17", "AQAAAAIAAYagAAAAEB3xSSo694mNwMuESegDxN8YiUiDj7BXbF3/oIqp2RgHfnU+oZtBN/shmljGQ8Px2w==", "64a0909b-5b11-41e4-9d0b-1feebf2b48dd" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "someOtherUserId123456788",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1563be4e-ae91-4b7e-91e7-4e063ccd781e", "AQAAAAIAAYagAAAAEDYCXXTyJ8glgTXKUMfVLIYNDIKBf3xqms1LJtHFZtuBM/eH5Dvp0NBGNFMJ55k4hw==", "a441e1ca-d0af-4382-a24d-ee2f41c86d2b" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "someOtherUserId123456789",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "cefe474a-3fae-44d2-a0ad-71e91c256afb", "AQAAAAIAAYagAAAAEMZqhELtZcpfvMWaz7z30fqDXtzm3ZCDkEdPF4bdfDe7QpyQ3si29+gNc+/TC7rw/A==", "86697625-b900-4e72-a5c8-9c286e50e573" });
        }
    }
}

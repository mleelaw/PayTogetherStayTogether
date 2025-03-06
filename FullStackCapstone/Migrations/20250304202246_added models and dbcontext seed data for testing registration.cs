using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FullStackCapstone.Migrations
{
    /// <inheritdoc />
    public partial class addedmodelsanddbcontextseeddatafortestingregistration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dbc40bc6-0829-4ac5-a3ed-180f5e916a5f",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b260050e-d6f3-4cc0-b36a-6d436bc5e2c9", "AQAAAAIAAYagAAAAEH4ZTyoXlHOr7XaP0SXTZ74HHhB0RmFQNThyTsgBVg402HIT8tigWDKUeai133zbsw==", "1735c309-17cc-437c-9655-bf0d2049c1f0" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "someOtherUserId123456789",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "48218683-c3a8-4033-a1e4-c56fc3cf9627", "AQAAAAIAAYagAAAAEG/48n31gdUpxs6XSxIpsj9HOVayWJ8qDVFUeDq2okXoxbs9UrwUIKlRyP+uOyeN4g==", "f42ea9a1-68e2-4c50-9eea-1f597c45d394" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dbc40bc6-0829-4ac5-a3ed-180f5e916a5f",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "41b97aa3-b3c8-4daa-af17-0dd507e8123d", "AQAAAAIAAYagAAAAENjA+7O5i2m/YFuLrlZBmttNZTr+gxmW4gDaMwKW0U2E5rv8aqek5Oj/dFO6Uz81Lw==", "7b2a5934-d2c4-4207-945e-f33a7a7af39e" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "someOtherUserId123456789",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "001b662f-1ce5-402a-86d9-2856b3a04b3e", "AQAAAAIAAYagAAAAEHS9LQxbZyO8bBZR9/onEjVXWNNbXu/glCMvPyemHqYBamGsoizbwucFhGK0Dfh19Q==", "ca449521-324f-42e3-a2e5-74b8aac405a1" });
        }
    }
}

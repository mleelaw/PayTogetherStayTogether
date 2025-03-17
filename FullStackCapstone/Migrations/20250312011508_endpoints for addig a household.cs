using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FullStackCapstone.Migrations
{
    /// <inheritdoc />
    public partial class endpointsforaddigahousehold : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dbc40bc6-0829-4ac5-a3ed-180f5e916a5f",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1762790c-cb64-4363-8f84-eb24bd4bba58", "AQAAAAIAAYagAAAAEA23hN6nDjA+ojHk0hBSdjpX3pOSbBqp3xZ2JqCZy/gVuEDZyMa0LEP5XAHrbkMbkg==", "97ef510c-3deb-4223-8262-218103383beb" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "someOtherUserId123456788",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6b85e992-f247-493f-9693-4286977f3f12", "AQAAAAIAAYagAAAAEJgUKgPTwSjoPwt3Y7TbFZjCa+Xy9vri+QZ5gtxMDOLbmUnhR0QZx1tkLoTg092eIw==", "e0b2862a-a939-41c8-bb64-ffa812f997d4" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "someOtherUserId123456789",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e80c78d8-69e6-4bd4-9de5-e837846f904c", "AQAAAAIAAYagAAAAEHTFRJVqW8u/dFQwdjtgQo+iO9Hw2kuO7EBJuG2Pp6d9y+1RcU5iuDdCAKdql22ouQ==", "757c4524-cf71-4e52-9b61-04b422c8a39f" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dbc40bc6-0829-4ac5-a3ed-180f5e916a5f",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "731e0955-3f37-4293-b082-3353fca9022c", "AQAAAAIAAYagAAAAEKnThfbE1/5rACZWT3R05ZM77BREU+c6i06cl+S6nFZymzCvnn/o5IRNHN+4mCxSsg==", "0f45ea7e-b042-4b7c-a2b7-9c6b68c147e6" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "someOtherUserId123456788",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "224d384d-8873-47a2-a5f2-0799acafeb0a", "AQAAAAIAAYagAAAAEIPKJQL0GGzeA81y1YJFSuFW/FyoVxyrsc9GPyxSfJ6pC9EKJEct1OCs9FyZd/IJog==", "01b2fdd0-57b5-4533-b02a-f230b33e7443" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "someOtherUserId123456789",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a95e6a07-cad9-4d4c-af7c-64a35bef3fc4", "AQAAAAIAAYagAAAAEGe7vlY7KGnMn64ORD264juz4uGMJmUSgxsE3h7p1ZH9n6+Vr8cmNBGs2IyCLW1iVw==", "1eafd3ce-5689-431e-838a-b65b1936aa73" });
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FullStackCapstone.Migrations
{
    /// <inheritdoc />
    public partial class addedmodelsanddbcontextseeddatafortesting : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "dfcde332-19d2-4078-8deb-72f54818bf20",
                column: "NormalizedName",
                value: "USER");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "dfcde332-19d2-4078-8deb-72f54818bf20",
                column: "NormalizedName",
                value: "user");

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
    }
}

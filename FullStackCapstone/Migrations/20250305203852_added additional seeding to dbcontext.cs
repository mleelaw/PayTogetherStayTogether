using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FullStackCapstone.Migrations
{
    /// <inheritdoc />
    public partial class addedadditionalseedingtodbcontext : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dbc40bc6-0829-4ac5-a3ed-180f5e916a5f",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "196f8517-5a40-417d-8f46-842f9947db3e", "AQAAAAIAAYagAAAAEMzR+s5CSOCAHFA7owNjYr6sV1HBBYu9NoUOLnfRn+2fvxRWz6fP0dB1qwHKA27kLQ==", "22bafa19-851c-4f68-acfb-6d8d40548193" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "someOtherUserId123456789",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "347325ef-9354-495a-b1de-992e22700e0f", "AQAAAAIAAYagAAAAEGXmRxaTAgQVxKgXSuxonbz6zKU9BV35MXW8K05AB4ew5lTtR4wAD0xKOvGauNzK0A==", "c69ebf17-7d00-4cc1-8449-c059640b5ce1" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "someOtherUserId123456788", 0, "c086243e-b11e-48bc-b8fa-f527af89c1ac", "maezell@gmail.com", false, false, null, null, null, "AQAAAAIAAYagAAAAEMxDfkKIGSszuLoyvdp1xuKqepYpjzJbl1LPirQtmb8NB/YnK5HApo/T7jEneglfRg==", null, false, "c15482ba-52d3-4c9e-997f-10185eb493cb", false, "Abigail" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "dfcde332-19d2-4078-8deb-72f54818bf20", "someOtherUserId123456788" });

            migrationBuilder.InsertData(
                table: "UserProfiles",
                columns: new[] { "Id", "Address", "FirstName", "IdentityUserId", "LastName" },
                values: new object[] { 3, "123 Street Road", "Abigail", "someOtherUserId123456788", "Ezell" });

            migrationBuilder.InsertData(
                table: "HouseholdUsers",
                columns: new[] { "Id", "HouseholdId", "IsActive", "IsAdmin", "UserProfileId" },
                values: new object[] { 2, 1, true, false, 3 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "dfcde332-19d2-4078-8deb-72f54818bf20", "someOtherUserId123456788" });

            migrationBuilder.DeleteData(
                table: "HouseholdUsers",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "UserProfiles",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "someOtherUserId123456788");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dbc40bc6-0829-4ac5-a3ed-180f5e916a5f",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3dfb39ad-0d6d-4722-875c-7565d30a1cab", "AQAAAAIAAYagAAAAEJ+oXWMA66ZdcycGMFbKzUQqAyI35lZI1q3ZsMUfPmnwJpoPm+S3BuEF9+W8k368GQ==", "551dd3c6-6cc9-4ce4-b18f-91d957950079" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "someOtherUserId123456789",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "25aea1f8-24dc-43b4-af13-41ade53c0192", "AQAAAAIAAYagAAAAEIIAxV3Biqg1KwYUyk/JCkZM6E/R6NF4SIAtW1ooUwL+5WRMO/qXTPOzjCfDo6Sx6w==", "2745f59e-3fa5-4393-9b45-0977bb2aecf7" });
        }
    }
}

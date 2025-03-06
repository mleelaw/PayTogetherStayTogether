using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FullStackCapstone.Migrations
{
    /// <inheritdoc />
    public partial class addedadditionalseedingtodbcontextforinitialrun : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dbc40bc6-0829-4ac5-a3ed-180f5e916a5f",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ceadb0d6-7413-42e7-a2bf-d163418c92b4", "AQAAAAIAAYagAAAAEIT4yxg6+ZLvqsR4fwKDlk5RCY0qqMDPK0rqMPvU5SKIZzYbIacyFOfzkXcowBOJZQ==", "ec040a92-c304-4d8e-beb5-1a772b2dca21" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "someOtherUserId123456788",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7d659e56-a496-44c9-a0c8-237486b28968", "AQAAAAIAAYagAAAAEPHlEL/q64U/WBfKafMVc4gg6Qlh47hg8OCdr7iWS/NQH20ZIAvUMGIerg7yLHC1Rg==", "68e6b71e-6ac2-40b7-8aa5-878910517ba3" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "someOtherUserId123456789",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6da0a170-7372-4a95-9e57-6c570f2a75b0", "AQAAAAIAAYagAAAAEG6C4x6WupbWKhP9WETwtgJaJUlEF1IJ6gzDbDal+9j2dI595m4ynh7AOfN5QYeYBw==", "237d30ce-3686-4fff-a2b7-96222c4b0d5f" });

            migrationBuilder.InsertData(
                table: "Expenses",
                columns: new[] { "Id", "Amount", "CategoryId", "DateOfExpense", "Description", "FrequencyId", "HouseholdId", "IsFavorite", "PurchasedById", "PurchasedByUserId", "isRecurring" },
                values: new object[,]
                {
                    { 2, 33.00m, 2, new DateTime(2023, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "WaffleHouse", null, 1, false, null, 3, false },
                    { 3, 1900m, 1, new DateTime(2023, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Rent", 4, 1, true, null, 3, true }
                });

            migrationBuilder.InsertData(
                table: "Incomes",
                columns: new[] { "Id", "Amount", "CreatedById", "FrequencyId", "HouseholdId", "IsFavorite", "IsFrequent", "Source" },
                values: new object[] { 2, 2400m, 3, 3, 1, true, true, "Work" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Expenses",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Expenses",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Incomes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dbc40bc6-0829-4ac5-a3ed-180f5e916a5f",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "196f8517-5a40-417d-8f46-842f9947db3e", "AQAAAAIAAYagAAAAEMzR+s5CSOCAHFA7owNjYr6sV1HBBYu9NoUOLnfRn+2fvxRWz6fP0dB1qwHKA27kLQ==", "22bafa19-851c-4f68-acfb-6d8d40548193" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "someOtherUserId123456788",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c086243e-b11e-48bc-b8fa-f527af89c1ac", "AQAAAAIAAYagAAAAEMxDfkKIGSszuLoyvdp1xuKqepYpjzJbl1LPirQtmb8NB/YnK5HApo/T7jEneglfRg==", "c15482ba-52d3-4c9e-997f-10185eb493cb" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "someOtherUserId123456789",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "347325ef-9354-495a-b1de-992e22700e0f", "AQAAAAIAAYagAAAAEGXmRxaTAgQVxKgXSuxonbz6zKU9BV35MXW8K05AB4ew5lTtR4wAD0xKOvGauNzK0A==", "c69ebf17-7d00-4cc1-8449-c059640b5ce1" });
        }
    }
}

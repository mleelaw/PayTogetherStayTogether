﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FullStackCapstone.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedExpenseControllerIsRecurringWasIncorrectCasing : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dbc40bc6-0829-4ac5-a3ed-180f5e916a5f",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d2c2d1f8-9fe3-4898-85b5-8641a4f21c3d", "AQAAAAIAAYagAAAAEIDAKm0m17D/MqqiZMgbAzhxffQOAeUd1zxJq6I9p6b1cuADvahKbo+0IvXPhS9sxQ==", "95cc5433-f496-4171-a8c5-41fabaebdc81" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "someOtherUserId123456788",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d46dfdcc-1f3e-46c8-8877-af24fb1a1562", "AQAAAAIAAYagAAAAELb45bwktVKcmDVlxv76oIntyo9RuNcgrmD6aY4VqW9fIWPTNjkxJ0qK5c8Di1irAg==", "11f01bc7-8842-4b8d-8ac0-bf8640666f72" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "someOtherUserId123456789",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0a8c010f-85de-4899-9e65-b785bc600f09", "AQAAAAIAAYagAAAAED1DboNI09JqzumdFHJlZc12skediEm1NLKLMLBb77e0GlfCH3Su6nAZvlPt7aEXKg==", "f62fb1a4-c496-41d8-a14f-880b7d2d5ddd" });
        }
    }
}

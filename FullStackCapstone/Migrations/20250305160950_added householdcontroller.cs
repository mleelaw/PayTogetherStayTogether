using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FullStackCapstone.Migrations
{
    /// <inheritdoc />
    public partial class addedhouseholdcontroller : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dbc40bc6-0829-4ac5-a3ed-180f5e916a5f",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f1e8b99f-54f9-46b9-8f50-a1ea90725907", "AQAAAAIAAYagAAAAEL3ePew/jUbtNrjwZ0QgCKp74vck9zUWmq/+/cIlbBscOLdS8qwJUFLpIjgFgFwRXQ==", "99b9b74e-9e8c-4683-b928-e0e1b66227aa" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "someOtherUserId123456789",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "02f20131-e954-4048-a822-b36dcc3ef1d4", "AQAAAAIAAYagAAAAEGqUjf+crceEFAVXzJLH3m62UkVrSVOcXXvzI93LMXPlsf7XN5I79frQnHa0U5AN1w==", "e8c623ea-3f29-4579-a2f2-bff4b4d77970" });
        }
    }
}

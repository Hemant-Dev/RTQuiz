using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RTQuiz.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddedHashPassword : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "PasswordHash",
                value: "lo71hy5cdTEFukwEI5WqXIF3prqDBuwTBvuZkknj6Nw9RK6L7tuW7YmRa1U+exR7");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "PasswordHash",
                value: "password");
        }
    }
}

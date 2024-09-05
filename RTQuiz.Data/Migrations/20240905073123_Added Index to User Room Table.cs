using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RTQuiz.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddedIndextoUserRoomTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "PasswordHash",
                value: "lIeZR9+HCL0fhJ6xsxjYjO27c8bBP7vf0vfRMB72xGgmzqy/izf3JD5Oj1GyfKN9");

            migrationBuilder.CreateIndex(
                name: "IX_UserRooms_UserId_RoomId",
                table: "UserRooms",
                columns: new[] { "UserId", "RoomId" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_UserRooms_UserId_RoomId",
                table: "UserRooms");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "PasswordHash",
                value: "6+FpLTfstBo2wGsgvKweHClDl6qAX2W3BeWwZQ1W2qLymWeyAVKknDzdybKcdas6");
        }
    }
}

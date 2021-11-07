using Microsoft.EntityFrameworkCore.Migrations;

namespace UserBookSubscribeAPI.Migrations
{
    public partial class CHangeEntityDataTypes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropForeignKey(
            //    name: "FK_Subscribe_Book_BookID",
            //    table: "Subscribe");

            //migrationBuilder.DropForeignKey(
            //    name: "FK_Subscribe_User_UserID",
            //    table: "Subscribe");

            migrationBuilder.DropIndex(
                name: "IX_Subscribe_BookID",
                table: "Subscribe");

            migrationBuilder.DropIndex(
                name: "IX_Subscribe_UserID",
                table: "Subscribe");

            migrationBuilder.RenameColumn(
                name: "UserID",
                table: "Subscribe",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "BookID",
                table: "Subscribe",
                newName: "BookId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Subscribe",
                newName: "UserID");

            migrationBuilder.RenameColumn(
                name: "BookId",
                table: "Subscribe",
                newName: "BookID");

            migrationBuilder.CreateIndex(
                name: "IX_Subscribe_BookID",
                table: "Subscribe",
                column: "BookID");

            migrationBuilder.CreateIndex(
                name: "IX_Subscribe_UserID",
                table: "Subscribe",
                column: "UserID");

            migrationBuilder.AddForeignKey(
                name: "FK_Subscribe_Book_BookID",
                table: "Subscribe",
                column: "BookID",
                principalTable: "Book",
                principalColumn: "BookId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Subscribe_User_UserID",
                table: "Subscribe",
                column: "UserID",
                principalTable: "User",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

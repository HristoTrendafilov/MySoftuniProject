using Microsoft.EntityFrameworkCore.Migrations;

namespace AllAboutGames.Data.Migrations
{
    public partial class ChangedCommentsForGamesEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CommentsForGames_Games_GameId",
                table: "CommentsForGames");

            migrationBuilder.DropForeignKey(
                name: "FK_CommentsForGames_AspNetUsers_UserId",
                table: "CommentsForGames");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CommentsForGames",
                table: "CommentsForGames");

            migrationBuilder.RenameTable(
                name: "CommentsForGames",
                newName: "GameComments");

            migrationBuilder.RenameIndex(
                name: "IX_CommentsForGames_UserId",
                table: "GameComments",
                newName: "IX_GameComments_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_CommentsForGames_GameId",
                table: "GameComments",
                newName: "IX_GameComments_GameId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_GameComments",
                table: "GameComments",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_GameComments_Games_GameId",
                table: "GameComments",
                column: "GameId",
                principalTable: "Games",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_GameComments_AspNetUsers_UserId",
                table: "GameComments",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GameComments_Games_GameId",
                table: "GameComments");

            migrationBuilder.DropForeignKey(
                name: "FK_GameComments_AspNetUsers_UserId",
                table: "GameComments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GameComments",
                table: "GameComments");

            migrationBuilder.RenameTable(
                name: "GameComments",
                newName: "CommentsForGames");

            migrationBuilder.RenameIndex(
                name: "IX_GameComments_UserId",
                table: "CommentsForGames",
                newName: "IX_CommentsForGames_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_GameComments_GameId",
                table: "CommentsForGames",
                newName: "IX_CommentsForGames_GameId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CommentsForGames",
                table: "CommentsForGames",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CommentsForGames_Games_GameId",
                table: "CommentsForGames",
                column: "GameId",
                principalTable: "Games",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CommentsForGames_AspNetUsers_UserId",
                table: "CommentsForGames",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

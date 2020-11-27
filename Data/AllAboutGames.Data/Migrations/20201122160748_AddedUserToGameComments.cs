namespace AllAboutGames.Data.Migrations
{
    using Microsoft.EntityFrameworkCore.Migrations;

    public partial class AddedUserToGameComments : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "CommentsForGames",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CommentsForGames_UserId",
                table: "CommentsForGames",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_CommentsForGames_AspNetUsers_UserId",
                table: "CommentsForGames",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CommentsForGames_AspNetUsers_UserId",
                table: "CommentsForGames");

            migrationBuilder.DropIndex(
                name: "IX_CommentsForGames_UserId",
                table: "CommentsForGames");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "CommentsForGames");
        }
    }
}

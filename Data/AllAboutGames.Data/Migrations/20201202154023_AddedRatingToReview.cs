using Microsoft.EntityFrameworkCore.Migrations;

namespace AllAboutGames.Data.Migrations
{
    public partial class AddedRatingToReview : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RatingId",
                table: "Reviews",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_RatingId",
                table: "Reviews",
                column: "RatingId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_Ratings_RatingId",
                table: "Reviews",
                column: "RatingId",
                principalTable: "Ratings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_Ratings_RatingId",
                table: "Reviews");

            migrationBuilder.DropIndex(
                name: "IX_Reviews_RatingId",
                table: "Reviews");

            migrationBuilder.DropColumn(
                name: "RatingId",
                table: "Reviews");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

namespace AllAboutGames.Data.Migrations
{
    public partial class ChangesToRatingProperty : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RateValue",
                table: "Ratings");

            migrationBuilder.AddColumn<byte>(
                name: "Value",
                table: "Ratings",
                nullable: false,
                defaultValue: (byte)0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Value",
                table: "Ratings");

            migrationBuilder.AddColumn<byte>(
                name: "RateValue",
                table: "Ratings",
                type: "tinyint",
                nullable: false,
                defaultValue: (byte)0);
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AllAboutGames.Data.Migrations
{
    public partial class ChangesToFeedBackEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "FeedBack",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedOn",
                table: "FeedBack",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "FeedBack",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateIndex(
                name: "IX_FeedBack_IsDeleted",
                table: "FeedBack",
                column: "IsDeleted");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_FeedBack_IsDeleted",
                table: "FeedBack");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "FeedBack");

            migrationBuilder.DropColumn(
                name: "DeletedOn",
                table: "FeedBack");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "FeedBack");
        }
    }
}

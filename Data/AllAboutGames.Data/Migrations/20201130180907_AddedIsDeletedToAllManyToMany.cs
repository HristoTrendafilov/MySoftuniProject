using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AllAboutGames.Data.Migrations
{
    public partial class AddedIsDeletedToAllManyToMany : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedOn",
                table: "GamesPlatforms",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "GamesPlatforms",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedOn",
                table: "GamesLanguages",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "GamesLanguages",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedOn",
                table: "GamesGenres",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "GamesGenres",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateIndex(
                name: "IX_GamesPlatforms_IsDeleted",
                table: "GamesPlatforms",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_GamesLanguages_IsDeleted",
                table: "GamesLanguages",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_GamesGenres_IsDeleted",
                table: "GamesGenres",
                column: "IsDeleted");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_GamesPlatforms_IsDeleted",
                table: "GamesPlatforms");

            migrationBuilder.DropIndex(
                name: "IX_GamesLanguages_IsDeleted",
                table: "GamesLanguages");

            migrationBuilder.DropIndex(
                name: "IX_GamesGenres_IsDeleted",
                table: "GamesGenres");

            migrationBuilder.DropColumn(
                name: "DeletedOn",
                table: "GamesPlatforms");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "GamesPlatforms");

            migrationBuilder.DropColumn(
                name: "DeletedOn",
                table: "GamesLanguages");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "GamesLanguages");

            migrationBuilder.DropColumn(
                name: "DeletedOn",
                table: "GamesGenres");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "GamesGenres");
        }
    }
}

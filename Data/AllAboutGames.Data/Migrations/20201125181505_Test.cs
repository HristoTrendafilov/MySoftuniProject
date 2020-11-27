namespace AllAboutGames.Data.Migrations
{
    using Microsoft.EntityFrameworkCore.Migrations;

    public partial class Test : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Value",
                table: "Ratings",
                nullable: false,
                oldClrType: typeof(byte),
                oldType: "tinyint");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<byte>(
                name: "Value",
                table: "Ratings",
                type: "tinyint",
                nullable: false,
                oldClrType: typeof(int));
        }
    }
}

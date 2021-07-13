using Microsoft.EntityFrameworkCore.Migrations;

namespace capstone.Data.Migrations
{
    public partial class User : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "JusticeLeagueMembers",
                nullable: false,
                defaultValue: "144e1536-0f20-43e3-82e2-cdc7a5843bc9");

            migrationBuilder.CreateIndex(
                name: "IX_JusticeLeagueMembers_UserId",
                table: "JusticeLeagueMembers",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_JusticeLeagueMembers_UserId",
                table: "JusticeLeagueMembers");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "JusticeLeagueMembers");
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace capstone.Data.Migrations
{
    public partial class JusticeLeagueData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "JusticeLeagueMembers",
                columns: new[] { "Id", "Age", "Alias", "IsActiveMember", "MemberSince", "Name" },
                values: new object[] { 1, 45, "Clark Kent", true, new DateTime(1950, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Superman" });

            migrationBuilder.InsertData(
                table: "JusticeLeagueMembers",
                columns: new[] { "Id", "Age", "Alias", "IsActiveMember", "MemberSince", "Name" },
                values: new object[] { 2, 44, "Bruce Wayne", true, new DateTime(1950, 1, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "Batman" });

            migrationBuilder.InsertData(
                table: "JusticeLeagueMembers",
                columns: new[] { "Id", "Age", "Alias", "IsActiveMember", "MemberSince", "Name" },
                values: new object[] { 3, 37, "Diana Prince", true, new DateTime(1950, 2, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Wonder Women" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "JusticeLeagueMembers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "JusticeLeagueMembers",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "JusticeLeagueMembers",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}

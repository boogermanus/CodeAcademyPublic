using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CS321_W4D2_ExerciseLogAPI.Infrastructure.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ActivityTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true),
                    RecordType = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActivityTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Activities",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Date = table.Column<DateTime>(nullable: false),
                    ActivityTypeId = table.Column<int>(nullable: false),
                    Duration = table.Column<double>(nullable: false),
                    Distance = table.Column<double>(nullable: false),
                    UserId = table.Column<int>(nullable: false),
                    Notes = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Activities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Activities_ActivityTypes_ActivityTypeId",
                        column: x => x.ActivityTypeId,
                        principalTable: "ActivityTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Activities_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "ActivityTypes",
                columns: new[] { "Id", "Name", "RecordType" },
                values: new object[] { 1, "Running", 1 });

            migrationBuilder.InsertData(
                table: "ActivityTypes",
                columns: new[] { "Id", "Name", "RecordType" },
                values: new object[] { 2, "Weights", 0 });

            migrationBuilder.InsertData(
                table: "ActivityTypes",
                columns: new[] { "Id", "Name", "RecordType" },
                values: new object[] { 3, "Walking", 1 });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "Test User" });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "ActivityTypeId", "Date", "Distance", "Duration", "Notes", "UserId" },
                values: new object[] { 1, 1, new DateTime(2019, 6, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), 3.0, 30.0, "Hot!!!!", 1 });

            migrationBuilder.CreateIndex(
                name: "IX_Activities_ActivityTypeId",
                table: "Activities",
                column: "ActivityTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Activities_UserId",
                table: "Activities",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Activities");

            migrationBuilder.DropTable(
                name: "ActivityTypes");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}

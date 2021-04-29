using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CS321_W4D1_BookAPI.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Authors",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    BirthDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Authors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Publisher",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true),
                    FoundedYear = table.Column<int>(nullable: false),
                    CountryOfOrigin = table.Column<string>(nullable: true),
                    HeadQuartersLocation = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Publisher", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(nullable: true),
                    OriginalLanguage = table.Column<string>(nullable: true),
                    Genre = table.Column<string>(nullable: true),
                    PublicationYear = table.Column<int>(nullable: false),
                    AuthorId = table.Column<int>(nullable: false),
                    PublisherId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Books_Authors_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Authors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Books_Publisher_PublisherId",
                        column: x => x.PublisherId,
                        principalTable: "Publisher",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "Id", "BirthDate", "FirstName", "LastName" },
                values: new object[] { 1, new DateTime(1902, 2, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "John", "Steinbeck" });

            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "Id", "BirthDate", "FirstName", "LastName" },
                values: new object[] { 2, new DateTime(1947, 9, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Stephen", "King" });

            migrationBuilder.InsertData(
                table: "Publisher",
                columns: new[] { "Id", "CountryOfOrigin", "FoundedYear", "HeadQuartersLocation", "Name" },
                values: new object[] { 1, "USA", 1925, "NY, NY", "Viking Press" });

            migrationBuilder.InsertData(
                table: "Publisher",
                columns: new[] { "Id", "CountryOfOrigin", "FoundedYear", "HeadQuartersLocation", "Name" },
                values: new object[] { 2, "USA", 1897, "NY, NY", "Doubleday" });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "AuthorId", "Genre", "OriginalLanguage", "PublicationYear", "PublisherId", "Title" },
                values: new object[] { 1, 1, "Novel", "English", 1939, 1, "The Grapes of Wrath" });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "AuthorId", "Genre", "OriginalLanguage", "PublicationYear", "PublisherId", "Title" },
                values: new object[] { 2, 1, "Regional", "English", 1945, 1, "Cannery Row" });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "AuthorId", "Genre", "OriginalLanguage", "PublicationYear", "PublisherId", "Title" },
                values: new object[] { 3, 2, "Horror", "English", 1977, 2, "The Shining" });

            migrationBuilder.CreateIndex(
                name: "IX_Books_AuthorId",
                table: "Books",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_Books_PublisherId",
                table: "Books",
                column: "PublisherId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "Authors");

            migrationBuilder.DropTable(
                name: "Publisher");
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MovieGram.Data.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cinema",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cinema", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Movie",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    ThumbnailUrl = table.Column<string>(nullable: true),
                    FullImageUrl = table.Column<string>(nullable: true),
                    Plot = table.Column<string>(nullable: true),
                    Rating = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movie", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ShowTime",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    MovieId = table.Column<int>(nullable: false),
                    CinemaId = table.Column<int>(nullable: false),
                    Time = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShowTime", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShowTime_Cinema_CinemaId",
                        column: x => x.CinemaId,
                        principalTable: "Cinema",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ShowTime_Movie_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movie",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Cinema",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Cinema1" },
                    { 2, "Cinema2" },
                    { 3, "Cinema3" },
                    { 4, "Cinema4" },
                    { 5, "Cinema5" }
                });

            migrationBuilder.InsertData(
                table: "Movie",
                columns: new[] { "Id", "FullImageUrl", "Name", "Plot", "Rating", "ThumbnailUrl" },
                values: new object[,]
                {
                    { 1, "http://test.com/content/images/Movie1.png", "Movie1", "Plot1", 4, "http://test.com/content/thumbs/Movie1.png" },
                    { 2, "http://test.com/content/images/Movie2.png", "Movie2", "Plot2", 3, "http://test.com/content/thumbs/Movie2.png" },
                    { 3, "http://test.com/content/images/Movie3.png", "Movie3", "Plot3", 2, "http://test.com/content/thumbs/Movie3.png" },
                    { 4, "http://test.com/content/images/Movie4.png", "Movie4", "Plot4", 1, "http://test.com/content/thumbs/Movie4.png" },
                    { 5, "http://test.com/content/images/Movie5.png", "Movie5", "Plot5", 5, "http://test.com/content/thumbs/Movie5.png" }
                });

            migrationBuilder.InsertData(
                table: "ShowTime",
                columns: new[] { "Id", "CinemaId", "MovieId", "Time" },
                values: new object[,]
                {
                    { 1, 1, 1, new DateTime(2019, 5, 1, 14, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, 1, 1, new DateTime(2019, 6, 1, 14, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, 1, 1, new DateTime(2019, 7, 1, 14, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, 5, 2, new DateTime(2019, 5, 1, 14, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, 4, 3, new DateTime(2019, 5, 1, 14, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 6, 3, 3, new DateTime(2019, 5, 1, 14, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 7, 4, 4, new DateTime(2019, 5, 1, 14, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 8, 3, 4, new DateTime(2019, 6, 1, 14, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 9, 2, 4, new DateTime(2019, 6, 1, 14, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 10, 2, 5, new DateTime(2019, 6, 1, 14, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ShowTime_CinemaId",
                table: "ShowTime",
                column: "CinemaId");

            migrationBuilder.CreateIndex(
                name: "IX_ShowTime_MovieId",
                table: "ShowTime",
                column: "MovieId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ShowTime");

            migrationBuilder.DropTable(
                name: "Cinema");

            migrationBuilder.DropTable(
                name: "Movie");
        }
    }
}

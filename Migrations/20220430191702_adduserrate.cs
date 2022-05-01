using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FinalProjectAPI.Migrations
{
    public partial class adduserrate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Movies",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    errorMessage = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movies", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Series",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    errorMessage = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Series", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Movie",
                columns: table => new
                {
                    id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    rank = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    fullTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    year = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    crew = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    imDbRating = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    imDbRatingCount = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Genre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Moviesid = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movie", x => x.id);
                    table.ForeignKey(
                        name: "FK_Movie_Movies_Moviesid",
                        column: x => x.Moviesid,
                        principalTable: "Movies",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "Serie",
                columns: table => new
                {
                    id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    rank = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    fullTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    year = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    image = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    crew = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    imDbRating = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    imDbRatingCount = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Seriesid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Serie", x => x.id);
                    table.ForeignKey(
                        name: "FK_Serie_Series_Seriesid",
                        column: x => x.Seriesid,
                        principalTable: "Series",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "userRates",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    rate = table.Column<int>(type: "int", nullable: false),
                    movieid = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_userRates", x => x.id);
                    table.ForeignKey(
                        name: "FK_userRates_Movie_movieid",
                        column: x => x.movieid,
                        principalTable: "Movie",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Seriedetail",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    episodename = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    episodelength = table.Column<int>(type: "int", nullable: false),
                    serieid = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Seriedetail", x => x.id);
                    table.ForeignKey(
                        name: "FK_Seriedetail_Serie_serieid",
                        column: x => x.serieid,
                        principalTable: "Serie",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Movie_Moviesid",
                table: "Movie",
                column: "Moviesid");

            migrationBuilder.CreateIndex(
                name: "IX_Serie_Seriesid",
                table: "Serie",
                column: "Seriesid");

            migrationBuilder.CreateIndex(
                name: "IX_Seriedetail_serieid",
                table: "Seriedetail",
                column: "serieid");

            migrationBuilder.CreateIndex(
                name: "IX_userRates_movieid",
                table: "userRates",
                column: "movieid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Seriedetail");

            migrationBuilder.DropTable(
                name: "userRates");

            migrationBuilder.DropTable(
                name: "Serie");

            migrationBuilder.DropTable(
                name: "Movie");

            migrationBuilder.DropTable(
                name: "Series");

            migrationBuilder.DropTable(
                name: "Movies");
        }
    }
}

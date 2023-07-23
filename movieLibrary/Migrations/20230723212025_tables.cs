using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace movieLibrary.Migrations
{
    /// <inheritdoc />
    public partial class tables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Actors",
                columns: table => new
                {
                    Idactor = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Fortune = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    Birthdate = table.Column<DateTime>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Actors", x => x.Idactor);
                });

            migrationBuilder.CreateTable(
                name: "Genders",
                columns: table => new
                {
                    Idgender = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genders", x => x.Idgender);
                });

            migrationBuilder.CreateTable(
                name: "Movies",
                columns: table => new
                {
                    Idmovie = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Oncinema = table.Column<bool>(type: "bit", nullable: false),
                    Daterelease = table.Column<DateTime>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movies", x => x.Idmovie);
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    Idcomment = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Comments = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Recommend = table.Column<bool>(type: "bit", nullable: false),
                    Movieid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Idcomment);
                    table.ForeignKey(
                        name: "FK_Comments_Movies_Movieid",
                        column: x => x.Movieid,
                        principalTable: "Movies",
                        principalColumn: "Idmovie",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GenderMovie",
                columns: table => new
                {
                    GendersIdgender = table.Column<int>(type: "int", nullable: false),
                    MoviesIdmovie = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GenderMovie", x => new { x.GendersIdgender, x.MoviesIdmovie });
                    table.ForeignKey(
                        name: "FK_GenderMovie_Genders_GendersIdgender",
                        column: x => x.GendersIdgender,
                        principalTable: "Genders",
                        principalColumn: "Idgender",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GenderMovie_Movies_MoviesIdmovie",
                        column: x => x.MoviesIdmovie,
                        principalTable: "Movies",
                        principalColumn: "Idmovie",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MovieActors",
                columns: table => new
                {
                    Movieid = table.Column<int>(type: "int", nullable: false),
                    Actorid = table.Column<int>(type: "int", nullable: false),
                    Character = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Order = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieActors", x => new { x.Actorid, x.Movieid });
                    table.ForeignKey(
                        name: "FK_MovieActors_Actors_Actorid",
                        column: x => x.Actorid,
                        principalTable: "Actors",
                        principalColumn: "Idactor",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MovieActors_Movies_Movieid",
                        column: x => x.Movieid,
                        principalTable: "Movies",
                        principalColumn: "Idmovie",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Comments_Movieid",
                table: "Comments",
                column: "Movieid");

            migrationBuilder.CreateIndex(
                name: "IX_GenderMovie_MoviesIdmovie",
                table: "GenderMovie",
                column: "MoviesIdmovie");

            migrationBuilder.CreateIndex(
                name: "IX_MovieActors_Movieid",
                table: "MovieActors",
                column: "Movieid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "GenderMovie");

            migrationBuilder.DropTable(
                name: "MovieActors");

            migrationBuilder.DropTable(
                name: "Genders");

            migrationBuilder.DropTable(
                name: "Actors");

            migrationBuilder.DropTable(
                name: "Movies");
        }
    }
}

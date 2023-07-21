using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace movieLibrary.Migrations
{
    /// <inheritdoc />
    public partial class relationshipMoviesActors : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                        principalColumn: "Id_actor",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MovieActors_Movies_Movieid",
                        column: x => x.Movieid,
                        principalTable: "Movies",
                        principalColumn: "Id_movie",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MovieActors_Movieid",
                table: "MovieActors",
                column: "Movieid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MovieActors");
        }
    }
}

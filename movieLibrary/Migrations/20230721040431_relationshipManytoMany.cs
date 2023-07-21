using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace movieLibrary.Migrations
{
    /// <inheritdoc />
    public partial class relationshipManytoMany : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GenderMovie",
                columns: table => new
                {
                    GendersId_gender = table.Column<int>(type: "int", nullable: false),
                    MoviesId_movie = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GenderMovie", x => new { x.GendersId_gender, x.MoviesId_movie });
                    table.ForeignKey(
                        name: "FK_GenderMovie_Genders_GendersId_gender",
                        column: x => x.GendersId_gender,
                        principalTable: "Genders",
                        principalColumn: "Id_gender",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GenderMovie_Movies_MoviesId_movie",
                        column: x => x.MoviesId_movie,
                        principalTable: "Movies",
                        principalColumn: "Id_movie",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GenderMovie_MoviesId_movie",
                table: "GenderMovie",
                column: "MoviesId_movie");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GenderMovie");
        }
    }
}

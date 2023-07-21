using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace movieLibrary.Migrations
{
    /// <inheritdoc />
    public partial class relationshipMovieComment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MovieId_movie",
                table: "Comments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Movie_ID",
                table: "Comments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Comments_MovieId_movie",
                table: "Comments",
                column: "MovieId_movie");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Movies_MovieId_movie",
                table: "Comments",
                column: "MovieId_movie",
                principalTable: "Movies",
                principalColumn: "Id_movie",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Movies_MovieId_movie",
                table: "Comments");

            migrationBuilder.DropIndex(
                name: "IX_Comments_MovieId_movie",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "MovieId_movie",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "Movie_ID",
                table: "Comments");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AppMovieCase.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class decimalUpdatePopularity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categories_Categories_CategoryId",
                table: "Categories");

            migrationBuilder.DropTable(
                name: "GenreMovie");

            migrationBuilder.RenameColumn(
                name: "CategoryId",
                table: "Categories",
                newName: "CategoryModelId");

            migrationBuilder.RenameIndex(
                name: "IX_Categories_CategoryId",
                table: "Categories",
                newName: "IX_Categories_CategoryModelId");

            migrationBuilder.CreateTable(
                name: "GenreModelMovieModel",
                columns: table => new
                {
                    MovieGenresId = table.Column<int>(type: "int", nullable: false),
                    MoviesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GenreModelMovieModel", x => new { x.MovieGenresId, x.MoviesId });
                    table.ForeignKey(
                        name: "FK_GenreModelMovieModel_Genres_MovieGenresId",
                        column: x => x.MovieGenresId,
                        principalTable: "Genres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GenreModelMovieModel_Movies_MoviesId",
                        column: x => x.MoviesId,
                        principalTable: "Movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GenreModelMovieModel_MoviesId",
                table: "GenreModelMovieModel",
                column: "MoviesId");

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_Categories_CategoryModelId",
                table: "Categories",
                column: "CategoryModelId",
                principalTable: "Categories",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categories_Categories_CategoryModelId",
                table: "Categories");

            migrationBuilder.DropTable(
                name: "GenreModelMovieModel");

            migrationBuilder.RenameColumn(
                name: "CategoryModelId",
                table: "Categories",
                newName: "CategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_Categories_CategoryModelId",
                table: "Categories",
                newName: "IX_Categories_CategoryId");

            migrationBuilder.CreateTable(
                name: "GenreMovie",
                columns: table => new
                {
                    MovieGenresId = table.Column<int>(type: "int", nullable: false),
                    MoviesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GenreMovie", x => new { x.MovieGenresId, x.MoviesId });
                    table.ForeignKey(
                        name: "FK_GenreMovie_Genres_MovieGenresId",
                        column: x => x.MovieGenresId,
                        principalTable: "Genres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GenreMovie_Movies_MoviesId",
                        column: x => x.MoviesId,
                        principalTable: "Movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GenreMovie_MoviesId",
                table: "GenreMovie",
                column: "MoviesId");

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_Categories_CategoryId",
                table: "Categories",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id");
        }
    }
}

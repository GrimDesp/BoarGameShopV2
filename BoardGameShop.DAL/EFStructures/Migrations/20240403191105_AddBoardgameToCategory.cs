using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BoardGameShop.DAL.EFStructures.Migrations
{
    /// <inheritdoc />
    public partial class AddBoardgameToCategory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BoardgameCategory");

            migrationBuilder.DropColumn(
                name: "CategoryIds",
                table: "BoardGames");

            migrationBuilder.CreateTable(
                name: "BoardgameToCategory",
                columns: table => new
                {
                    BoardgameId = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BoardgameToCategory", x => new { x.BoardgameId, x.CategoryId });
                    table.ForeignKey(
                        name: "FK_BoardgameToCategory_BoardGames_BoardgameId",
                        column: x => x.BoardgameId,
                        principalTable: "BoardGames",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BoardgameToCategory_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BoardgameToCategory_CategoryId",
                table: "BoardgameToCategory",
                column: "CategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BoardgameToCategory");

            migrationBuilder.AddColumn<string>(
                name: "CategoryIds",
                table: "BoardGames",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "BoardgameCategory",
                columns: table => new
                {
                    CategoriesId = table.Column<int>(type: "int", nullable: false),
                    CategoryIds = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BoardgameCategory", x => new { x.CategoriesId, x.CategoryIds });
                    table.ForeignKey(
                        name: "FK_BoardgameCategory_BoardGames_CategoryIds",
                        column: x => x.CategoryIds,
                        principalTable: "BoardGames",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BoardgameCategory_Categories_CategoriesId",
                        column: x => x.CategoriesId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BoardgameCategory_CategoryIds",
                table: "BoardgameCategory",
                column: "CategoryIds");
        }
    }
}

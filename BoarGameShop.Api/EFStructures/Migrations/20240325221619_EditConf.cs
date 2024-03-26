using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BoardGameShop.Api.EFStructures.Migrations
{
    /// <inheritdoc />
    public partial class EditConf : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categories_BoardGames_CategoryIds",
                table: "Categories");

            migrationBuilder.DropIndex(
                name: "IX_Categories_CategoryIds",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "CategoryIds",
                table: "Categories");

            migrationBuilder.CreateTable(
                name: "BoardGameCategory",
                columns: table => new
                {
                    CategoriesId = table.Column<int>(type: "int", nullable: false),
                    CategoryIds = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BoardGameCategory", x => new { x.CategoriesId, x.CategoryIds });
                    table.ForeignKey(
                        name: "FK_BoardGameCategory_BoardGames_CategoryIds",
                        column: x => x.CategoryIds,
                        principalTable: "BoardGames",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BoardGameCategory_Categories_CategoriesId",
                        column: x => x.CategoriesId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BoardGameCategory_CategoryIds",
                table: "BoardGameCategory",
                column: "CategoryIds");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BoardGameCategory");

            migrationBuilder.AddColumn<int>(
                name: "CategoryIds",
                table: "Categories",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Categories_CategoryIds",
                table: "Categories",
                column: "CategoryIds");

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_BoardGames_CategoryIds",
                table: "Categories",
                column: "CategoryIds",
                principalTable: "BoardGames",
                principalColumn: "Id");
        }
    }
}

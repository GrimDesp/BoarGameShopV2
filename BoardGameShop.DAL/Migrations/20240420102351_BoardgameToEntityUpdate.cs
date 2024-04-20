using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BoardGameShop.DAL.Migrations
{
    /// <inheritdoc />
    public partial class BoardgameToEntityUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BoardgameToCategory_BoardGames_BoardgameId",
                table: "BoardgameToCategory");

            migrationBuilder.DropForeignKey(
                name: "FK_BoardgameToCategory_Categories_CategoryId",
                table: "BoardgameToCategory");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BoardgameToCategory",
                table: "BoardgameToCategory");

            migrationBuilder.RenameTable(
                name: "BoardgameToCategory",
                newName: "BoardgamesToCategory");

            migrationBuilder.RenameIndex(
                name: "IX_BoardgameToCategory_CategoryId",
                table: "BoardgamesToCategory",
                newName: "IX_BoardgamesToCategory_CategoryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BoardgamesToCategory",
                table: "BoardgamesToCategory",
                columns: new[] { "BoardgameId", "CategoryId" });

            migrationBuilder.AddForeignKey(
                name: "FK_BoardgamesToCategory_BoardGames_BoardgameId",
                table: "BoardgamesToCategory",
                column: "BoardgameId",
                principalTable: "BoardGames",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BoardgamesToCategory_Categories_CategoryId",
                table: "BoardgamesToCategory",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BoardgamesToCategory_BoardGames_BoardgameId",
                table: "BoardgamesToCategory");

            migrationBuilder.DropForeignKey(
                name: "FK_BoardgamesToCategory_Categories_CategoryId",
                table: "BoardgamesToCategory");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BoardgamesToCategory",
                table: "BoardgamesToCategory");

            migrationBuilder.RenameTable(
                name: "BoardgamesToCategory",
                newName: "BoardgameToCategory");

            migrationBuilder.RenameIndex(
                name: "IX_BoardgamesToCategory_CategoryId",
                table: "BoardgameToCategory",
                newName: "IX_BoardgameToCategory_CategoryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BoardgameToCategory",
                table: "BoardgameToCategory",
                columns: new[] { "BoardgameId", "CategoryId" });

            migrationBuilder.AddForeignKey(
                name: "FK_BoardgameToCategory_BoardGames_BoardgameId",
                table: "BoardgameToCategory",
                column: "BoardgameId",
                principalTable: "BoardGames",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BoardgameToCategory_Categories_CategoryId",
                table: "BoardgameToCategory",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

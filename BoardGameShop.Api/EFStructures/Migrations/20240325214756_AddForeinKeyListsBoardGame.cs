using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BoardGameShop.Api.EFStructures.Migrations
{
    /// <inheritdoc />
    public partial class AddForeinKeyListsBoardGame : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MechanicIds",
                table: "Mechanics",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CategoryIds",
                table: "Categories",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Mechanics_MechanicIds",
                table: "Mechanics",
                column: "MechanicIds");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Mechanics_BoardGames_MechanicIds",
                table: "Mechanics",
                column: "MechanicIds",
                principalTable: "BoardGames",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categories_BoardGames_CategoryIds",
                table: "Categories");

            migrationBuilder.DropForeignKey(
                name: "FK_Mechanics_BoardGames_MechanicIds",
                table: "Mechanics");

            migrationBuilder.DropIndex(
                name: "IX_Mechanics_MechanicIds",
                table: "Mechanics");

            migrationBuilder.DropIndex(
                name: "IX_Categories_CategoryIds",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "MechanicIds",
                table: "Mechanics");

            migrationBuilder.DropColumn(
                name: "CategoryIds",
                table: "Categories");
        }
    }
}

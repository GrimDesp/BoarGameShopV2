using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BoardGameShop.Api.EFStructures.Migrations
{
    /// <inheritdoc />
    public partial class UpdatingArraysInBoard : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "numbers",
                table: "BoardGames",
                newName: "MechanicIds");

            migrationBuilder.AddColumn<string>(
                name: "CategoryIds",
                table: "BoardGames",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CategoryIds",
                table: "BoardGames");

            migrationBuilder.RenameColumn(
                name: "MechanicIds",
                table: "BoardGames",
                newName: "numbers");
        }
    }
}

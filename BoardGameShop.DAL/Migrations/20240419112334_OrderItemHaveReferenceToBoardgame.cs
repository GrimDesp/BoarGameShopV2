using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BoardGameShop.DAL.Migrations
{
    /// <inheritdoc />
    public partial class OrderItemHaveReferenceToBoardgame : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "BoardGames",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_ItemId",
                table: "OrderItems",
                column: "ItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderItems_BoardGames_ItemId",
                table: "OrderItems",
                column: "ItemId",
                principalTable: "BoardGames",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderItems_BoardGames_ItemId",
                table: "OrderItems");

            migrationBuilder.DropIndex(
                name: "IX_OrderItems_ItemId",
                table: "OrderItems");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "BoardGames");
        }
    }
}

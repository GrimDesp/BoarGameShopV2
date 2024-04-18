using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BoardGameShop.DAL.Migrations
{
    /// <inheritdoc />
    public partial class VendorOrderFix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Publishers_PublisherId",
                table: "Orders");

            migrationBuilder.RenameColumn(
                name: "PublisherId",
                table: "Orders",
                newName: "VendorId");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_PublisherId",
                table: "Orders",
                newName: "IX_Orders_VendorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Vendors_VendorId",
                table: "Orders",
                column: "VendorId",
                principalTable: "Vendors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Vendors_VendorId",
                table: "Orders");

            migrationBuilder.RenameColumn(
                name: "VendorId",
                table: "Orders",
                newName: "PublisherId");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_VendorId",
                table: "Orders",
                newName: "IX_Orders_PublisherId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Publishers_PublisherId",
                table: "Orders",
                column: "PublisherId",
                principalTable: "Publishers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BoardGameShop.DAL.EFStructures.Migrations
{
    /// <inheritdoc />
    public partial class OrderPaymentDate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CreationTime",
                table: "Orders",
                newName: "CreationDate");

            migrationBuilder.RenameColumn(
                name: "CompletionTime",
                table: "Orders",
                newName: "PaymentDate");

            migrationBuilder.AddColumn<DateTime>(
                name: "CompletionDate",
                table: "Orders",
                type: "datetime2",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CompletionDate",
                table: "Orders");

            migrationBuilder.RenameColumn(
                name: "PaymentDate",
                table: "Orders",
                newName: "CompletionTime");

            migrationBuilder.RenameColumn(
                name: "CreationDate",
                table: "Orders",
                newName: "CreationTime");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BoardGameShop.Api.EFStructures.Migrations
{
    /// <inheritdoc />
    public partial class MechanicCategoryConfiguration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Mechanics_BoardGames_MechanicIds",
                table: "Mechanics");

            migrationBuilder.DropIndex(
                name: "IX_Mechanics_MechanicIds",
                table: "Mechanics");

            migrationBuilder.DropColumn(
                name: "MechanicIds",
                table: "Mechanics");

            migrationBuilder.CreateTable(
                name: "BoardGameMechanic",
                columns: table => new
                {
                    MechanicIds = table.Column<int>(type: "int", nullable: false),
                    MechanicsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BoardGameMechanic", x => new { x.MechanicIds, x.MechanicsId });
                    table.ForeignKey(
                        name: "FK_BoardGameMechanic_BoardGames_MechanicIds",
                        column: x => x.MechanicIds,
                        principalTable: "BoardGames",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BoardGameMechanic_Mechanics_MechanicsId",
                        column: x => x.MechanicsId,
                        principalTable: "Mechanics",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BoardGameMechanic_MechanicsId",
                table: "BoardGameMechanic",
                column: "MechanicsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BoardGameMechanic");

            migrationBuilder.AddColumn<int>(
                name: "MechanicIds",
                table: "Mechanics",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Mechanics_MechanicIds",
                table: "Mechanics",
                column: "MechanicIds");

            migrationBuilder.AddForeignKey(
                name: "FK_Mechanics_BoardGames_MechanicIds",
                table: "Mechanics",
                column: "MechanicIds",
                principalTable: "BoardGames",
                principalColumn: "Id");
        }
    }
}

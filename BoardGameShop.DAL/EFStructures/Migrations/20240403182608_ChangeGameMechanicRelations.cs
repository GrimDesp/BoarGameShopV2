using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BoardGameShop.DAL.EFStructures.Migrations
{
    /// <inheritdoc />
    public partial class ChangeGameMechanicRelations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ArtistBoardGame_Artists_ArtistsId",
                table: "ArtistBoardGame");

            migrationBuilder.DropForeignKey(
                name: "FK_ArtistBoardGame_BoardGames_ArtistIds",
                table: "ArtistBoardGame");

            migrationBuilder.DropForeignKey(
                name: "FK_AuthorBoardGame_Authors_DesignersId",
                table: "AuthorBoardGame");

            migrationBuilder.DropForeignKey(
                name: "FK_AuthorBoardGame_BoardGames_DesignerIds",
                table: "AuthorBoardGame");

            migrationBuilder.DropForeignKey(
                name: "FK_BoardGameCategory_BoardGames_CategoryIds",
                table: "BoardGameCategory");

            migrationBuilder.DropForeignKey(
                name: "FK_BoardGameCategory_Categories_CategoriesId",
                table: "BoardGameCategory");

            migrationBuilder.DropTable(
                name: "BoardGameMechanic");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BoardGameCategory",
                table: "BoardGameCategory");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AuthorBoardGame",
                table: "AuthorBoardGame");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ArtistBoardGame",
                table: "ArtistBoardGame");

            migrationBuilder.DropColumn(
                name: "MechanicIds",
                table: "BoardGames");

            migrationBuilder.RenameTable(
                name: "BoardGameCategory",
                newName: "BoardgameCategory");

            migrationBuilder.RenameTable(
                name: "AuthorBoardGame",
                newName: "AuthorBoardgame");

            migrationBuilder.RenameTable(
                name: "ArtistBoardGame",
                newName: "ArtistBoardgame");

            migrationBuilder.RenameIndex(
                name: "IX_BoardGameCategory_CategoryIds",
                table: "BoardgameCategory",
                newName: "IX_BoardgameCategory_CategoryIds");

            migrationBuilder.RenameIndex(
                name: "IX_AuthorBoardGame_DesignersId",
                table: "AuthorBoardgame",
                newName: "IX_AuthorBoardgame_DesignersId");

            migrationBuilder.RenameIndex(
                name: "IX_ArtistBoardGame_ArtistsId",
                table: "ArtistBoardgame",
                newName: "IX_ArtistBoardgame_ArtistsId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BoardgameCategory",
                table: "BoardgameCategory",
                columns: new[] { "CategoriesId", "CategoryIds" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_AuthorBoardgame",
                table: "AuthorBoardgame",
                columns: new[] { "DesignerIds", "DesignersId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_ArtistBoardgame",
                table: "ArtistBoardgame",
                columns: new[] { "ArtistIds", "ArtistsId" });

            migrationBuilder.CreateTable(
                name: "BoardgameToMechanic",
                columns: table => new
                {
                    BoardgameId = table.Column<int>(type: "int", nullable: false),
                    MechanicId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BoardgameToMechanic", x => new { x.MechanicId, x.BoardgameId });
                    table.ForeignKey(
                        name: "FK_BoardgameToMechanic_BoardGames_BoardgameId",
                        column: x => x.BoardgameId,
                        principalTable: "BoardGames",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BoardgameToMechanic_Mechanics_MechanicId",
                        column: x => x.MechanicId,
                        principalTable: "Mechanics",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BoardgameToMechanic_BoardgameId",
                table: "BoardgameToMechanic",
                column: "BoardgameId");

            migrationBuilder.AddForeignKey(
                name: "FK_ArtistBoardgame_Artists_ArtistsId",
                table: "ArtistBoardgame",
                column: "ArtistsId",
                principalTable: "Artists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ArtistBoardgame_BoardGames_ArtistIds",
                table: "ArtistBoardgame",
                column: "ArtistIds",
                principalTable: "BoardGames",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AuthorBoardgame_Authors_DesignersId",
                table: "AuthorBoardgame",
                column: "DesignersId",
                principalTable: "Authors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AuthorBoardgame_BoardGames_DesignerIds",
                table: "AuthorBoardgame",
                column: "DesignerIds",
                principalTable: "BoardGames",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BoardgameCategory_BoardGames_CategoryIds",
                table: "BoardgameCategory",
                column: "CategoryIds",
                principalTable: "BoardGames",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BoardgameCategory_Categories_CategoriesId",
                table: "BoardgameCategory",
                column: "CategoriesId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ArtistBoardgame_Artists_ArtistsId",
                table: "ArtistBoardgame");

            migrationBuilder.DropForeignKey(
                name: "FK_ArtistBoardgame_BoardGames_ArtistIds",
                table: "ArtistBoardgame");

            migrationBuilder.DropForeignKey(
                name: "FK_AuthorBoardgame_Authors_DesignersId",
                table: "AuthorBoardgame");

            migrationBuilder.DropForeignKey(
                name: "FK_AuthorBoardgame_BoardGames_DesignerIds",
                table: "AuthorBoardgame");

            migrationBuilder.DropForeignKey(
                name: "FK_BoardgameCategory_BoardGames_CategoryIds",
                table: "BoardgameCategory");

            migrationBuilder.DropForeignKey(
                name: "FK_BoardgameCategory_Categories_CategoriesId",
                table: "BoardgameCategory");

            migrationBuilder.DropTable(
                name: "BoardgameToMechanic");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BoardgameCategory",
                table: "BoardgameCategory");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AuthorBoardgame",
                table: "AuthorBoardgame");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ArtistBoardgame",
                table: "ArtistBoardgame");

            migrationBuilder.RenameTable(
                name: "BoardgameCategory",
                newName: "BoardGameCategory");

            migrationBuilder.RenameTable(
                name: "AuthorBoardgame",
                newName: "AuthorBoardGame");

            migrationBuilder.RenameTable(
                name: "ArtistBoardgame",
                newName: "ArtistBoardGame");

            migrationBuilder.RenameIndex(
                name: "IX_BoardgameCategory_CategoryIds",
                table: "BoardGameCategory",
                newName: "IX_BoardGameCategory_CategoryIds");

            migrationBuilder.RenameIndex(
                name: "IX_AuthorBoardgame_DesignersId",
                table: "AuthorBoardGame",
                newName: "IX_AuthorBoardGame_DesignersId");

            migrationBuilder.RenameIndex(
                name: "IX_ArtistBoardgame_ArtistsId",
                table: "ArtistBoardGame",
                newName: "IX_ArtistBoardGame_ArtistsId");

            migrationBuilder.AddColumn<string>(
                name: "MechanicIds",
                table: "BoardGames",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_BoardGameCategory",
                table: "BoardGameCategory",
                columns: new[] { "CategoriesId", "CategoryIds" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_AuthorBoardGame",
                table: "AuthorBoardGame",
                columns: new[] { "DesignerIds", "DesignersId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_ArtistBoardGame",
                table: "ArtistBoardGame",
                columns: new[] { "ArtistIds", "ArtistsId" });

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

            migrationBuilder.AddForeignKey(
                name: "FK_ArtistBoardGame_Artists_ArtistsId",
                table: "ArtistBoardGame",
                column: "ArtistsId",
                principalTable: "Artists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ArtistBoardGame_BoardGames_ArtistIds",
                table: "ArtistBoardGame",
                column: "ArtistIds",
                principalTable: "BoardGames",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AuthorBoardGame_Authors_DesignersId",
                table: "AuthorBoardGame",
                column: "DesignersId",
                principalTable: "Authors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AuthorBoardGame_BoardGames_DesignerIds",
                table: "AuthorBoardGame",
                column: "DesignerIds",
                principalTable: "BoardGames",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BoardGameCategory_BoardGames_CategoryIds",
                table: "BoardGameCategory",
                column: "CategoryIds",
                principalTable: "BoardGames",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BoardGameCategory_Categories_CategoriesId",
                table: "BoardGameCategory",
                column: "CategoriesId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

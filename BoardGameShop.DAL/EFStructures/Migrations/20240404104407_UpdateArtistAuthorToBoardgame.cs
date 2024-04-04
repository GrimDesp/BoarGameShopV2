using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BoardGameShop.DAL.EFStructures.Migrations
{
    /// <inheritdoc />
    public partial class UpdateArtistAuthorToBoardgame : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ArtistBoardgame");

            migrationBuilder.DropTable(
                name: "AuthorBoardgame");

            migrationBuilder.DropColumn(
                name: "ArtistIds",
                table: "BoardGames");

            migrationBuilder.DropColumn(
                name: "DesignerIds",
                table: "BoardGames");

            migrationBuilder.CreateTable(
                name: "BoardgameToArtist",
                columns: table => new
                {
                    BoardgameId = table.Column<int>(type: "int", nullable: false),
                    ArtistId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BoardgameToArtist", x => new { x.BoardgameId, x.ArtistId });
                    table.ForeignKey(
                        name: "FK_BoardgameToArtist_Artists_ArtistId",
                        column: x => x.ArtistId,
                        principalTable: "Artists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BoardgameToArtist_BoardGames_BoardgameId",
                        column: x => x.BoardgameId,
                        principalTable: "BoardGames",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BoardgameToAuthor",
                columns: table => new
                {
                    BoardgameId = table.Column<int>(type: "int", nullable: false),
                    AuthorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BoardgameToAuthor", x => new { x.AuthorId, x.BoardgameId });
                    table.ForeignKey(
                        name: "FK_BoardgameToAuthor_Authors_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Authors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BoardgameToAuthor_BoardGames_BoardgameId",
                        column: x => x.BoardgameId,
                        principalTable: "BoardGames",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BoardgameToArtist_ArtistId",
                table: "BoardgameToArtist",
                column: "ArtistId");

            migrationBuilder.CreateIndex(
                name: "IX_BoardgameToAuthor_BoardgameId",
                table: "BoardgameToAuthor",
                column: "BoardgameId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BoardgameToArtist");

            migrationBuilder.DropTable(
                name: "BoardgameToAuthor");

            migrationBuilder.AddColumn<string>(
                name: "ArtistIds",
                table: "BoardGames",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DesignerIds",
                table: "BoardGames",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ArtistBoardgame",
                columns: table => new
                {
                    ArtistIds = table.Column<int>(type: "int", nullable: false),
                    ArtistsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArtistBoardgame", x => new { x.ArtistIds, x.ArtistsId });
                    table.ForeignKey(
                        name: "FK_ArtistBoardgame_Artists_ArtistsId",
                        column: x => x.ArtistsId,
                        principalTable: "Artists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ArtistBoardgame_BoardGames_ArtistIds",
                        column: x => x.ArtistIds,
                        principalTable: "BoardGames",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AuthorBoardgame",
                columns: table => new
                {
                    DesignerIds = table.Column<int>(type: "int", nullable: false),
                    DesignersId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuthorBoardgame", x => new { x.DesignerIds, x.DesignersId });
                    table.ForeignKey(
                        name: "FK_AuthorBoardgame_Authors_DesignersId",
                        column: x => x.DesignersId,
                        principalTable: "Authors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AuthorBoardgame_BoardGames_DesignerIds",
                        column: x => x.DesignerIds,
                        principalTable: "BoardGames",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ArtistBoardgame_ArtistsId",
                table: "ArtistBoardgame",
                column: "ArtistsId");

            migrationBuilder.CreateIndex(
                name: "IX_AuthorBoardgame_DesignersId",
                table: "AuthorBoardgame",
                column: "DesignersId");
        }
    }
}

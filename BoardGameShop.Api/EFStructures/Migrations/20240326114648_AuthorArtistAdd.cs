using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BoardGameShop.Api.EFStructures.Migrations
{
    /// <inheritdoc />
    public partial class AuthorArtistAdd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Creators");

            migrationBuilder.AlterColumn<string>(
                name: "MechanicIds",
                table: "BoardGames",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "CategoryIds",
                table: "BoardGames",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

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
                name: "Artists",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TimeSpam = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Artists", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Authors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TimeSpam = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Authors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ArtistBoardGame",
                columns: table => new
                {
                    ArtistIds = table.Column<int>(type: "int", nullable: false),
                    ArtistsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArtistBoardGame", x => new { x.ArtistIds, x.ArtistsId });
                    table.ForeignKey(
                        name: "FK_ArtistBoardGame_Artists_ArtistsId",
                        column: x => x.ArtistsId,
                        principalTable: "Artists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ArtistBoardGame_BoardGames_ArtistIds",
                        column: x => x.ArtistIds,
                        principalTable: "BoardGames",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AuthorBoardGame",
                columns: table => new
                {
                    DesignerIds = table.Column<int>(type: "int", nullable: false),
                    DesignersId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuthorBoardGame", x => new { x.DesignerIds, x.DesignersId });
                    table.ForeignKey(
                        name: "FK_AuthorBoardGame_Authors_DesignersId",
                        column: x => x.DesignersId,
                        principalTable: "Authors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AuthorBoardGame_BoardGames_DesignerIds",
                        column: x => x.DesignerIds,
                        principalTable: "BoardGames",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ArtistBoardGame_ArtistsId",
                table: "ArtistBoardGame",
                column: "ArtistsId");

            migrationBuilder.CreateIndex(
                name: "IX_AuthorBoardGame_DesignersId",
                table: "AuthorBoardGame",
                column: "DesignersId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ArtistBoardGame");

            migrationBuilder.DropTable(
                name: "AuthorBoardGame");

            migrationBuilder.DropTable(
                name: "Artists");

            migrationBuilder.DropTable(
                name: "Authors");

            migrationBuilder.DropColumn(
                name: "ArtistIds",
                table: "BoardGames");

            migrationBuilder.DropColumn(
                name: "DesignerIds",
                table: "BoardGames");

            migrationBuilder.AlterColumn<string>(
                name: "MechanicIds",
                table: "BoardGames",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CategoryIds",
                table: "BoardGames",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "Creators",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    TimeSpam = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Creators", x => x.Id);
                });
        }
    }
}

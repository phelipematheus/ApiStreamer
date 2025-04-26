using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Inclusao_Criador_Conteudo_ItemPlaylist : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Criador",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Criador", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Conteudo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Titulo = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Tipo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CriadorId = table.Column<int>(type: "int", nullable: false),
                    ConteudoId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Conteudo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Conteudo_Conteudo_ConteudoId",
                        column: x => x.ConteudoId,
                        principalTable: "Conteudo",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Conteudo_Criador_CriadorId",
                        column: x => x.CriadorId,
                        principalTable: "Criador",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ItemPlaylist",
                columns: table => new
                {
                    PlaylistId = table.Column<int>(type: "int", nullable: false),
                    ConteudoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemPlaylist", x => new { x.PlaylistId, x.ConteudoId });
                    table.ForeignKey(
                        name: "FK_ItemPlaylist_Conteudo_ConteudoId",
                        column: x => x.ConteudoId,
                        principalTable: "Conteudo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ItemPlaylist_Playlist_PlaylistId",
                        column: x => x.PlaylistId,
                        principalTable: "Playlist",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Conteudo_ConteudoId",
                table: "Conteudo",
                column: "ConteudoId");

            migrationBuilder.CreateIndex(
                name: "IX_Conteudo_CriadorId",
                table: "Conteudo",
                column: "CriadorId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemPlaylist_ConteudoId",
                table: "ItemPlaylist",
                column: "ConteudoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ItemPlaylist");

            migrationBuilder.DropTable(
                name: "Conteudo");

            migrationBuilder.DropTable(
                name: "Criador");
        }
    }
}

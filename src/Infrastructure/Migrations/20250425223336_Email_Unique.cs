using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Email_Unique : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Conteudo_Conteudo_ConteudoId",
                table: "Conteudo");

            migrationBuilder.DropForeignKey(
                name: "FK_ItemPlaylist_Conteudo_ConteudoId",
                table: "ItemPlaylist");

            migrationBuilder.DropForeignKey(
                name: "FK_ItemPlaylist_Playlist_PlaylistId",
                table: "ItemPlaylist");

            migrationBuilder.RenameColumn(
                name: "ConteudoId",
                table: "Conteudo",
                newName: "CriadorId1");

            migrationBuilder.RenameIndex(
                name: "IX_Conteudo_ConteudoId",
                table: "Conteudo",
                newName: "IX_Conteudo_CriadorId1");

            migrationBuilder.AddColumn<int>(
                name: "UsuarioId1",
                table: "Playlist",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ConteudoPlaylist",
                columns: table => new
                {
                    ConteudosId = table.Column<int>(type: "int", nullable: false),
                    PlaylistsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConteudoPlaylist", x => new { x.ConteudosId, x.PlaylistsId });
                    table.ForeignKey(
                        name: "FK_ConteudoPlaylist_Conteudo_ConteudosId",
                        column: x => x.ConteudosId,
                        principalTable: "Conteudo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ConteudoPlaylist_Playlist_PlaylistsId",
                        column: x => x.PlaylistsId,
                        principalTable: "Playlist",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_Email",
                table: "Usuario",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Playlist_UsuarioId1",
                table: "Playlist",
                column: "UsuarioId1");

            migrationBuilder.CreateIndex(
                name: "IX_ConteudoPlaylist_PlaylistsId",
                table: "ConteudoPlaylist",
                column: "PlaylistsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Conteudo_Criador_CriadorId1",
                table: "Conteudo",
                column: "CriadorId1",
                principalTable: "Criador",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ItemPlaylist_Conteudo_ConteudoId",
                table: "ItemPlaylist",
                column: "ConteudoId",
                principalTable: "Conteudo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ItemPlaylist_Playlist_PlaylistId",
                table: "ItemPlaylist",
                column: "PlaylistId",
                principalTable: "Playlist",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Playlist_Usuario_UsuarioId1",
                table: "Playlist",
                column: "UsuarioId1",
                principalTable: "Usuario",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Conteudo_Criador_CriadorId1",
                table: "Conteudo");

            migrationBuilder.DropForeignKey(
                name: "FK_ItemPlaylist_Conteudo_ConteudoId",
                table: "ItemPlaylist");

            migrationBuilder.DropForeignKey(
                name: "FK_ItemPlaylist_Playlist_PlaylistId",
                table: "ItemPlaylist");

            migrationBuilder.DropForeignKey(
                name: "FK_Playlist_Usuario_UsuarioId1",
                table: "Playlist");

            migrationBuilder.DropTable(
                name: "ConteudoPlaylist");

            migrationBuilder.DropIndex(
                name: "IX_Usuario_Email",
                table: "Usuario");

            migrationBuilder.DropIndex(
                name: "IX_Playlist_UsuarioId1",
                table: "Playlist");

            migrationBuilder.DropColumn(
                name: "UsuarioId1",
                table: "Playlist");

            migrationBuilder.RenameColumn(
                name: "CriadorId1",
                table: "Conteudo",
                newName: "ConteudoId");

            migrationBuilder.RenameIndex(
                name: "IX_Conteudo_CriadorId1",
                table: "Conteudo",
                newName: "IX_Conteudo_ConteudoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Conteudo_Conteudo_ConteudoId",
                table: "Conteudo",
                column: "ConteudoId",
                principalTable: "Conteudo",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ItemPlaylist_Conteudo_ConteudoId",
                table: "ItemPlaylist",
                column: "ConteudoId",
                principalTable: "Conteudo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ItemPlaylist_Playlist_PlaylistId",
                table: "ItemPlaylist",
                column: "PlaylistId",
                principalTable: "Playlist",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

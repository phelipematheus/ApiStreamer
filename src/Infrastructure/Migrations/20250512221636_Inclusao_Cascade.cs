using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Inclusao_Cascade : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItemPlaylist_Conteudo_ConteudoId",
                table: "ItemPlaylist");

            migrationBuilder.DropForeignKey(
                name: "FK_ItemPlaylist_Playlist_PlaylistId",
                table: "ItemPlaylist");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItemPlaylist_Conteudo_ConteudoId",
                table: "ItemPlaylist");

            migrationBuilder.DropForeignKey(
                name: "FK_ItemPlaylist_Playlist_PlaylistId",
                table: "ItemPlaylist");

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
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ajuste_fk : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Conteudo_Criador_CriadorId1",
                table: "Conteudo");

            migrationBuilder.DropForeignKey(
                name: "FK_Playlist_Usuario_UsuarioId1",
                table: "Playlist");

            migrationBuilder.DropIndex(
                name: "IX_Playlist_UsuarioId1",
                table: "Playlist");

            migrationBuilder.DropIndex(
                name: "IX_Conteudo_CriadorId1",
                table: "Conteudo");

            migrationBuilder.DropColumn(
                name: "UsuarioId1",
                table: "Playlist");

            migrationBuilder.DropColumn(
                name: "CriadorId1",
                table: "Conteudo");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UsuarioId1",
                table: "Playlist",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CriadorId1",
                table: "Conteudo",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Playlist_UsuarioId1",
                table: "Playlist",
                column: "UsuarioId1");

            migrationBuilder.CreateIndex(
                name: "IX_Conteudo_CriadorId1",
                table: "Conteudo",
                column: "CriadorId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Conteudo_Criador_CriadorId1",
                table: "Conteudo",
                column: "CriadorId1",
                principalTable: "Criador",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Playlist_Usuario_UsuarioId1",
                table: "Playlist",
                column: "UsuarioId1",
                principalTable: "Usuario",
                principalColumn: "Id");
        }
    }
}

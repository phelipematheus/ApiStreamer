using Domain.Interfaces;

namespace Service.Interfaces;
public interface IPlaylistService
{
    Task<IPlaylist> AdicionarPlaylist(string nome, int usuarioId);
    Task<IPlaylist> AtualizarPlaylist(int id, string nome);
    Task<IPlaylist> ObterPlaylistPorId(int id);
    Task<IEnumerable<IPlaylist>> ObterPlaylistPorUsuarioId(int usuarioId);
    Task<IEnumerable<IPlaylist>> ObterTodasPlaylists();
    Task RemoverPlaylist(int id);
}

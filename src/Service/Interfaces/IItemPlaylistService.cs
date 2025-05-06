using Domain.Interfaces;

namespace Service.Interfaces
{
    public interface IItemPlaylistService
    {
        Task<IItemPlaylist> AdicionarItemPlaylist(int playlistId, int conteudoId);
        Task RemoverItemPlaylist(int playlistId, int conteudoId);
        Task<IItemPlaylist> ObterItemPlaylistPorId(int playlistId, int conteudoId);
        Task<IEnumerable<IItemPlaylist>> ObterItemPlaylistsPorPlaylistId(int playlistId);
        Task<IEnumerable<IItemPlaylist>> ObterItemPlaylistsPorConteudoId(int conteudoId);
        Task<IEnumerable<IItemPlaylist>> ObterItemPlaylistPorUsuarioId(int usuarioId);
    }
}

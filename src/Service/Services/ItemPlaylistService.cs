
using CrossCutting.Exceptions;
using Domain.Interfaces;
using Domain.Interfaces.Repositories;
using Service.Interfaces;

namespace Service.Services
{
    public class ItemPlaylistService(IItemPlaylistRepository itemPlaylistRepository, IPlaylistRepository playlistRepository, IConteudoRepository conteudoRepository, IUsuarioRepository usuarioRepository) : IItemPlaylistService
    {
        private readonly IItemPlaylistRepository _itemPlaylistRepository = itemPlaylistRepository;
        private readonly IPlaylistRepository _playlistRepository = playlistRepository;
        private readonly IConteudoRepository _conteudoRepository = conteudoRepository;
        private readonly IUsuarioRepository _usuarioRepository = usuarioRepository;

        public async Task<IItemPlaylist> AdicionarItemPlaylist(int playlistId, int conteudoId)
        {
            var playlist = _playlistRepository.GetPlaylistById(playlistId) ?? throw new NotFoundException("Playlist não encontrada.");
            var conteudo = _conteudoRepository.GetConteudoById(conteudoId) ?? throw new NotFoundException("Conteúdo não encontrado.");
            var itemPlaylist = new Domain.Entities.ItemPlaylist
            {
                PlaylistId = playlist.Id,
                ConteudoId = conteudo.Id,
                Playlist = (Domain.Entities.Playlist)playlist,
                Conteudo = (Domain.Entities.Conteudo)conteudo
            };
            _itemPlaylistRepository.AddItemPlaylist(itemPlaylist);
            await _itemPlaylistRepository.SaveChanges();
            return itemPlaylist;
        }
        public async Task RemoverItemPlaylist(int playlistId, int conteudoId)
        {
            var itemPlaylist = _itemPlaylistRepository.GetItemPlaylistById(playlistId, conteudoId) ?? throw new NotFoundException("Item da playlist não encontrado.");
            _itemPlaylistRepository.DeleteItemPlaylist(itemPlaylist.PlaylistId, itemPlaylist.ConteudoId);
            await _itemPlaylistRepository.SaveChanges();
        }

        public Task<IItemPlaylist> ObterItemPlaylistPorId(int playlistId, int conteudoId)
        {
            var itemPlaylist = _itemPlaylistRepository.GetItemPlaylistById(playlistId, conteudoId) ?? throw new NotFoundException("Item da playlist não encontrado.");
            return Task.FromResult<IItemPlaylist>(itemPlaylist);
        }


        public Task<IEnumerable<IItemPlaylist>> ObterItemPlaylistsPorPlaylistId(int playlistId)
        {
            var playlist = _playlistRepository.GetPlaylistById(playlistId) ?? throw new NotFoundException("Playlist não encontrada.");
            var itemPlaylists = _itemPlaylistRepository.GetItemPlaylistsByPlaylistId(playlist.Id);
            return Task.FromResult<IEnumerable<IItemPlaylist>>(itemPlaylists);
        }

        public Task<IEnumerable<IItemPlaylist>> ObterItemPlaylistsPorConteudoId(int conteudoId)
        {
            var conteudo = _conteudoRepository.GetConteudoById(conteudoId) ?? throw new NotFoundException("Conteúdo não encontrado.");
            var itemPlaylists = _itemPlaylistRepository.GetItemPlaylistsByConteudoId(conteudo.Id);
            return Task.FromResult<IEnumerable<IItemPlaylist>>(itemPlaylists);
        }
    }
}

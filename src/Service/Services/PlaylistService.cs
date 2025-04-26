using CrossCutting.Exceptions;
using Domain.Entities;
using Domain.Interfaces;
using Domain.Interfaces.Repositories;
using Service.Interfaces;

namespace Service.Playlist
{
    public class PlaylistService(IPlaylistRepository playlistRepository, IUsuarioRepository usuarioRepository) : IPlaylistService
    {
        private readonly IPlaylistRepository _playlistRepository = playlistRepository;
        private readonly IUsuarioRepository _usuarioRepository = usuarioRepository;

        public async Task<IPlaylist> AdicionarPlaylist(string nome, int usuarioId)
        {
            var usuario = _usuarioRepository.GetUsuarioById(usuarioId) ?? throw new NotFoundException("Usuário não encontrado.");
            var playlist = new Domain.Entities.Playlist(nome, usuarioId)
            {
                Usuario = (Domain.Entities.Usuario)usuario
            };

            _playlistRepository.AddPlaylist(playlist);
            await _playlistRepository.SaveChanges();

            return playlist;
        }

        public async Task<IPlaylist> AtualizarPlaylist(int id, string nome)
        {
            var playlist = _playlistRepository.GetPlaylistById(id) ?? throw new NotFoundException("Playlist não encontrada.");

            playlist.AtualizarDados(nome);

            _playlistRepository.UpdatePlaylist(playlist);
            await _playlistRepository.SaveChanges();

            return playlist;
        }

        public Task<IPlaylist> ObterPlaylistPorId(int id)
        {
            var playlist = _playlistRepository.GetPlaylistById(id) ?? throw new NotFoundException("Playlist não encontrada.");
            return Task.FromResult<IPlaylist>(playlist);
        }

        public Task<IEnumerable<IPlaylist>> ObterTodasPlaylists()
        {
            var playlists = _playlistRepository.GetAllPlaylists();
            return Task.FromResult<IEnumerable<IPlaylist>>(playlists);
        }

        public async Task RemoverPlaylist(int id)
        {
            var playlist = _playlistRepository.GetPlaylistById(id) ?? throw new NotFoundException("Playlist não encontrada.");

            _playlistRepository.DeletePlaylist(playlist.Id);
            await _playlistRepository.SaveChanges();
        }    
    }
}

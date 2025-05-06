using Domain.Entities;
using Domain.Interfaces;
using Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.Domain
{
    public class ItemPlaylistRepository(StreamerDbContext dbContext) : RepositoryBase(dbContext), IItemPlaylistRepository
    {
        private readonly StreamerDbContext _dbContext = dbContext;

        public void AddItemPlaylist(IItemPlaylist itemPlaylist)
        {
            _dbContext.PlaylistConteudos.Add((ItemPlaylist)itemPlaylist);
        }

        public void DeleteItemPlaylist(int playlistId, int conteudoId)
        {
            var itemPlaylist = _dbContext.PlaylistConteudos.Find(playlistId, conteudoId);
            if (itemPlaylist is not null)
            {
                _dbContext.PlaylistConteudos.Remove((ItemPlaylist)itemPlaylist);
            }
        }

        public IList<IItemPlaylist> GetItemPlaylistsByPlaylistId(int playlistId)
        {
            return _dbContext.PlaylistConteudos
                .Include(p => p.Playlist)
                .Include(p => p.Playlist.Usuario)
                .Include(p => p.Conteudo)
                .Include(p => p.Conteudo.Criador)
                .Where(p => p.PlaylistId == playlistId)
                .Cast<IItemPlaylist>()
                .ToList();
        }
        public IList<IItemPlaylist> GetItemPlaylistsByConteudoId(int conteudoId)
        {
            return _dbContext.PlaylistConteudos
                .Include(p => p.Playlist)
                .Include(p => p.Playlist.Usuario)
                .Include(p => p.Conteudo)
                .Include(p => p.Conteudo.Criador)
                .Where(p => p.ConteudoId == conteudoId)
                .Cast<IItemPlaylist>()
                .ToList();
        }
        public IList<IItemPlaylist> GetItemPlaylistsByUsuarioId(int usuarioId)
        {
            return _dbContext.PlaylistConteudos
                .Include(p => p.Playlist)
                .Include(p => p.Playlist.Usuario)
                .Include(p => p.Conteudo)
                .Include(p => p.Conteudo.Criador)
                .Where(p => p.Playlist.UsuarioId == usuarioId)
                .Cast<IItemPlaylist>()
                .ToList();
        }

        public IItemPlaylist GetItemPlaylistById(int playlistId, int conteudoId)
        {
            return _dbContext.PlaylistConteudos
                .Include(p => p.Playlist)
                .Include(p => p.Playlist.Usuario)
                .Include(p => p.Conteudo)
                .Include(p => p.Conteudo.Criador)
                .FirstOrDefault(p => p.PlaylistId == playlistId && p.ConteudoId == conteudoId)!;
        }
    
    }
}

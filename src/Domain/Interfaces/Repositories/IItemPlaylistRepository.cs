﻿using Domain.Entities;

namespace Domain.Interfaces.Repositories
{
    public interface IItemPlaylistRepository : IRepository
    {
        void AddItemPlaylist(IItemPlaylist itemPlaylist);
        void DeleteItemPlaylist(int playlistId, int conteudoId);
        IList<IItemPlaylist> GetItemPlaylistsByPlaylistId(int playlistId);
        IList<IItemPlaylist> GetItemPlaylistsByConteudoId(int conteudoId);
        IList<IItemPlaylist> GetItemPlaylistsByUsuarioId(int usuarioId);
        IItemPlaylist GetItemPlaylistById(int playlistId, int conteudoId);

    }
}

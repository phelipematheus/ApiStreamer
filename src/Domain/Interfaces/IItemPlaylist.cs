using Domain.Entities;

namespace Domain.Interfaces;

public interface IItemPlaylist
{
    int PlaylistId { get; }
    int ConteudoId { get; }
    Playlist Playlist { get; }
    Conteudo Conteudo { get; }
}

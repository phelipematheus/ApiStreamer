using Domain.Interfaces;

namespace Domain.Entities;

public class ItemPlaylist : IItemPlaylist
{
    public int PlaylistId { get; set; }
    public int ConteudoId { get; set; }
    public virtual Playlist Playlist { get; set; } = default!;
    public virtual Conteudo Conteudo { get; set; } = default!;
}

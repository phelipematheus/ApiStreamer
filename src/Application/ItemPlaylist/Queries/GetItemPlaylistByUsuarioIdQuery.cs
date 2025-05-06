using Application.Interfaces;
using Application.ItemPlaylist.ViewModels;

namespace Application.ItemPlaylist.Queries
{
    public sealed record GetItemPlaylistByUsuarioIdQuery(
        int UsuarioId
    ) : IQuery<IEnumerable<GetItemPlaylistByUsuarioIdViewModel>>;
}

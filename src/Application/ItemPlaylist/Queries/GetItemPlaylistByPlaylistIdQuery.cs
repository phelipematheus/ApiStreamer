using Application.Conteudos.ViewModels;
using Application.Interfaces;

namespace Application.ItemPlaylist.Queries;

public sealed record GetItemPlaylistByPlaylistIdQuery(
    int PlaylistId
) : IQuery<IEnumerable<ConteudoViewModel>>;

using Application.Interfaces;
using Application.Playlists.ViewModels;

namespace Application.Playlists.Queries;

public sealed record GetAllPlaylistsQuery() : IQuery<IEnumerable<PlaylistViewModel>>;

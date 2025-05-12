using Application.Interfaces;
using Application.Playlists.ViewModels;

namespace Application.Playlists.Queries;

public sealed record GetPlaylistByUsuarioIdQuery(int UsuarioId) : IQuery<IEnumerable<PlaylistViewModel>>;
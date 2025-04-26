using Application.Interfaces;
using Application.Playlists.ViewModels;

namespace Application.Playlists.Commands;

public sealed record UpdatePlaylistCommand(int Id, string Nome) : ICommand<PlaylistViewModel>;

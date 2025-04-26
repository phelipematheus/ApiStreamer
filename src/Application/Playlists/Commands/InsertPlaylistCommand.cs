using Application.Interfaces;
using Application.Playlists.ViewModels;

namespace Application.Playlists.Commands;

public sealed record InsertPlaylistCommand(string Nome, int UsuarioId) : ICommand<PlaylistViewModel>;

using Application.Global.ViewModels;
using Application.Interfaces;

namespace Application.Playlists.Commands;

public sealed record DeletePlaylistCommand(int Id) : ICommand<DeleteViewModel>;

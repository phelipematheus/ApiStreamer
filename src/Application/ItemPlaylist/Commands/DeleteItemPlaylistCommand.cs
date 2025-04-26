using Application.Global.ViewModels;
using Application.Interfaces;

namespace Application.ItemPlaylist.Commands;

public sealed record DeleteItemPlaylistCommand(
    int PlaylistId,
    int ConteudoId
) : ICommand<DeleteViewModel>;

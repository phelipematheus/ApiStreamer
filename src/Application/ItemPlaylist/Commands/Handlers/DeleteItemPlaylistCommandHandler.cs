using Application.Common;
using Application.Global.ViewModels;
using Microsoft.Extensions.Logging;
using Service.Interfaces;

namespace Application.ItemPlaylist.Commands.Handlers;

public sealed class DeleteItemPlaylistCommandHandler(
    IItemPlaylistService itemPlaylistService,
    ILogger<DeleteItemPlaylistCommandHandler> logger) :
    BaseCommandHandler<DeleteItemPlaylistCommand, DeleteViewModel>(logger)
{
    private readonly IItemPlaylistService _itemPlaylistService = itemPlaylistService;
    protected override async Task<DeleteViewModel> ExecuteAsync(DeleteItemPlaylistCommand request, CancellationToken cancellationToken)
    {
        await _itemPlaylistService.RemoverItemPlaylist(request.PlaylistId, request.ConteudoId);
        return new DeleteViewModel(request.ConteudoId, "Item da playlist removido com sucesso.");
    }
}

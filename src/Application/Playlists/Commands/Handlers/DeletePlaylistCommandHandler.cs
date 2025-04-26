using Application.Common;
using Application.Global.ViewModels;
using Microsoft.Extensions.Logging;
using Service.Interfaces;

namespace Application.Playlists.Commands.Handlers;

public sealed class DeletePlaylistCommandHandler(IPlaylistService playlistService, ILogger<DeletePlaylistCommandHandler> logger) :
    BaseCommandHandler<DeletePlaylistCommand, DeleteViewModel>(logger)
{
    private readonly IPlaylistService _playlistService = playlistService;
    protected override async Task<DeleteViewModel> ExecuteAsync(DeletePlaylistCommand request, CancellationToken cancellationToken)
    {
        await _playlistService.RemoverPlaylist(request.Id);
        return new DeleteViewModel(request.Id, "Conteúdo removido com sucesso.");
    }
}

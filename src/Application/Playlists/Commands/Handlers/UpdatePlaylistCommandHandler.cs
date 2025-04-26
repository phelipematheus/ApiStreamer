using Application.Common;
using Application.Playlists.ViewModels;
using Application.Usuarios.ViewModels;
using Microsoft.Extensions.Logging;
using Service.Interfaces;

namespace Application.Playlists.Commands.Handlers;

public sealed class UpdatePlaylistCommandHandler(
    IPlaylistService playlistService,
    ILogger<UpdatePlaylistCommandHandler> logger) :
    BaseCommandHandler<UpdatePlaylistCommand, PlaylistViewModel>(logger)
{
    private readonly IPlaylistService _playlistService = playlistService;
    protected override async Task<PlaylistViewModel> ExecuteAsync(UpdatePlaylistCommand request, CancellationToken cancellationToken)
    {
        var playlist = await _playlistService.AtualizarPlaylist(request.Id, request.Nome);
        return new PlaylistViewModel
        {
            Id = playlist.Id,
            Nome = playlist.Nome,
            Usuario = new UsuarioViewModel
            {
                Id = playlist.Usuario.Id,
                Nome = playlist.Usuario.Nome,
                Email = playlist.Usuario.Email
            }
        };
    }
}

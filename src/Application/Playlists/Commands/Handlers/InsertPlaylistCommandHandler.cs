using Application.Common;
using Application.Playlists.ViewModels;
using Application.Usuarios.ViewModels;
using Microsoft.Extensions.Logging;
using Service.Interfaces;

namespace Application.Playlists.Commands.Handlers;

public sealed class InsertPlaylistCommandHandler(IPlaylistService playlistService, ILogger<InsertPlaylistCommandHandler> logger) :
    BaseCommandHandler<InsertPlaylistCommand, PlaylistViewModel>(logger)
{
    private readonly IPlaylistService _playlistService = playlistService;
    protected override async Task<PlaylistViewModel> ExecuteAsync(InsertPlaylistCommand request, CancellationToken cancellationToken)
    {
        var playlist = await _playlistService.AdicionarPlaylist(request.Nome, request.UsuarioId);

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


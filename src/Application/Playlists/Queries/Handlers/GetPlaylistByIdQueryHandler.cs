using Application.Common;
using Application.Playlists.ViewModels;
using Application.Usuarios.ViewModels;
using Domain.Entities;
using Microsoft.Extensions.Logging;
using Service.Interfaces;

namespace Application.Playlists.Queries.Handlers;

public sealed class GetPlaylistByIdQueryHandler(
    IPlaylistService playlistService,
    ILogger<GetPlaylistByIdQueryHandler> logger) :
    BaseQueryHandler<GetPlaylistByIdQuery, PlaylistViewModel>(logger)
{
    private readonly IPlaylistService _playlistService = playlistService;
    protected override async Task<PlaylistViewModel> ExecuteAsync(GetPlaylistByIdQuery request, CancellationToken cancellationToken)
    {
        var playlist = await _playlistService.ObterPlaylistPorId(request.Id);
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

using Application.Common;
using Application.Playlists.ViewModels;
using Application.Usuarios.ViewModels;
using Domain.Entities;
using Microsoft.Extensions.Logging;
using Service.Interfaces;

namespace Application.Playlists.Queries.Handlers;

public sealed class GetAllPlaylistsQueryHandler(IPlaylistService playlistService, ILogger<GetAllPlaylistsQueryHandler> logger) :
    BaseQueryHandler<GetAllPlaylistsQuery, IEnumerable<PlaylistViewModel>>(logger)
{
    private readonly IPlaylistService _playlistService = playlistService;
    protected override async Task<IEnumerable<PlaylistViewModel>> ExecuteAsync(GetAllPlaylistsQuery request, CancellationToken cancellationToken)
    {
        var playlists = await _playlistService.ObterTodasPlaylists();
        return playlists.Select(playlist => new PlaylistViewModel
        {
            Id = playlist.Id,
            Nome = playlist.Nome,
            Usuario = new UsuarioViewModel
            {
                Id = playlist.Usuario.Id,
                Nome = playlist.Usuario.Nome,
                Email = playlist.Usuario.Email
            }
        });
    }
}

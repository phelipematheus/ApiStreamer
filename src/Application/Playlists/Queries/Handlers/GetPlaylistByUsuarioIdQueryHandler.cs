using Application.Common;
using Application.Playlists.ViewModels;
using Application.Usuarios.ViewModels;
using Microsoft.Extensions.Logging;
using Service.Interfaces;
using System.Collections;

namespace Application.Playlists.Queries.Handlers;

public sealed class GetPlaylistByUsuarioIdQueryHandler(IPlaylistService playlistService,
    ILogger<GetPlaylistByUsuarioIdQueryHandler> logger) :
    BaseQueryHandler<GetPlaylistByUsuarioIdQuery, IEnumerable<PlaylistViewModel>>(logger)
{
    private readonly IPlaylistService _playlistService = playlistService;
    protected override async Task<IEnumerable<PlaylistViewModel>> ExecuteAsync(GetPlaylistByUsuarioIdQuery request, CancellationToken cancellationToken)
    {
        var playlist = await _playlistService.ObterPlaylistPorUsuarioId(request.UsuarioId);

        return playlist.Select(p => new PlaylistViewModel
        {
            Id = p.Id,
            Nome = p.Nome,
            Usuario = new UsuarioViewModel
            {
                Id = p.Usuario.Id,
                Nome = p.Usuario.Nome,
                Email = p.Usuario.Email
            }
        });
    }
}
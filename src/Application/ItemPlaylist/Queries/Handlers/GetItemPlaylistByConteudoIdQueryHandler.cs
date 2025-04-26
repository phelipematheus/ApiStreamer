using Application.Common;
using Application.Playlists.ViewModels;
using Application.Usuarios.ViewModels;
using Microsoft.Extensions.Logging;
using Service.Interfaces;

namespace Application.ItemPlaylist.Queries.Handlers;

public sealed class GetItemPlaylistByConteudoIdQueryHandler(
    IItemPlaylistService itemPlaylistService,
    ILogger<GetItemPlaylistByConteudoIdQueryHandler> logger) :
    BaseQueryHandler<GetItemPlaylistByConteudoIdQuery, IEnumerable<PlaylistViewModel>>(logger)
{
    private readonly IItemPlaylistService _itemPlaylistService = itemPlaylistService;
    protected override async Task<IEnumerable<PlaylistViewModel>> ExecuteAsync(GetItemPlaylistByConteudoIdQuery request, CancellationToken cancellationToken)
    {
        var itemPlaylist = await _itemPlaylistService.ObterItemPlaylistsPorConteudoId(request.ConteudoId);

        return itemPlaylist.Select(p => new PlaylistViewModel
        {
            Id = p.Playlist.Id,
            Nome = p.Playlist.Nome,
            Usuario = new UsuarioViewModel
            {
                Id = p.Playlist.Usuario.Id,
                Nome = p.Playlist.Usuario.Nome,
                Email = p.Playlist.Usuario.Email
            }
        });
    }
}
using Application.Common;
using Application.Conteudos.ViewModels;
using Application.Criadores.ViewModels;
using Application.ItemPlaylist.ViewModels;
using Application.Playlists.ViewModels;
using Application.Usuarios.ViewModels;
using Microsoft.Extensions.Logging;
using Service.Interfaces;

namespace Application.ItemPlaylist.Queries.Handlers;

public sealed class GetItemPlaylistByUsuarioIdQueryHandler(IItemPlaylistService itemPlaylistService,
    ILogger<GetItemPlaylistByUsuarioIdQueryHandler> logger) :
    BaseQueryHandler<GetItemPlaylistByUsuarioIdQuery, IEnumerable<GetItemPlaylistByUsuarioIdViewModel>>(logger)
{
    private readonly IItemPlaylistService _itemPlaylistService = itemPlaylistService;
    protected override async Task<IEnumerable<GetItemPlaylistByUsuarioIdViewModel>> ExecuteAsync(GetItemPlaylistByUsuarioIdQuery request, CancellationToken cancellationToken)
    {
        var itemPlaylist = await _itemPlaylistService.ObterItemPlaylistPorUsuarioId(request.UsuarioId);

        var agrupadoPorPlaylist = itemPlaylist
            .GroupBy(p => p.Playlist.Id)
            .Select(group =>
            {
                var primeiraPlaylist = group.First().Playlist;

                return new GetItemPlaylistByUsuarioIdViewModel
                {
                    Playlist = new PlaylistViewModel
                    {
                        Id = primeiraPlaylist.Id,
                        Nome = primeiraPlaylist.Nome,
                        Usuario = new UsuarioViewModel
                        {
                            Id = primeiraPlaylist.Usuario.Id,
                            Nome = primeiraPlaylist.Usuario.Nome,
                            Email = primeiraPlaylist.Usuario.Email
                        }
                    },
                    Conteudos = group.Select(p => new ConteudoViewModel
                    {
                        Id = p.Conteudo.Id,
                        Tipo = p.Conteudo.Tipo,
                        Titulo = p.Conteudo.Titulo,
                        Criador = new CriadorViewModel
                        {
                            Id = p.Conteudo.Criador.Id,
                            Nome = p.Conteudo.Criador.Nome
                        }
                    }).ToList()
                };
            });
        return agrupadoPorPlaylist;
    }
}

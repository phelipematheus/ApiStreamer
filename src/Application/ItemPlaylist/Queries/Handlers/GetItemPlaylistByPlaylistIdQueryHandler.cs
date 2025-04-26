using Application.Common;
using Application.Conteudos.ViewModels;
using Application.Criadores.ViewModels;
using Application.ItemPlaylist.ViewModels;
using Domain.Entities;
using Microsoft.Extensions.Logging;
using Service.Interfaces;

namespace Application.ItemPlaylist.Queries.Handlers;

public sealed class GetItemPlaylistByPlaylistIdQueryHandler(
    IItemPlaylistService itemPlaylistService,
    ILogger<GetItemPlaylistByPlaylistIdQueryHandler> logger) :
    BaseQueryHandler<GetItemPlaylistByPlaylistIdQuery, IEnumerable<ConteudoViewModel>>(logger)
{
    private readonly IItemPlaylistService _itemPlaylistService = itemPlaylistService;
    protected override async Task<IEnumerable<ConteudoViewModel>> ExecuteAsync(GetItemPlaylistByPlaylistIdQuery request, CancellationToken cancellationToken)
    {
        var itemPlaylists = await _itemPlaylistService.ObterItemPlaylistsPorPlaylistId(request.PlaylistId);
        return itemPlaylists.Select(item => new ConteudoViewModel
        {
            Id = item.Conteudo.Id,
            Titulo = item.Conteudo.Titulo,
            Tipo = item.Conteudo.Tipo,
            Criador = new CriadorViewModel
            {
                Id = item.Conteudo.Criador.Id,
                Nome = item.Conteudo.Criador.Nome
            }
        });
    }
}

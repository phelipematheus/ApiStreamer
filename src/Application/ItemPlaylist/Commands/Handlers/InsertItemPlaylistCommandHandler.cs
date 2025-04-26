using Application.Common;
using Microsoft.Extensions.Logging;
using Service.Interfaces;
using Application.ItemPlaylist.ViewModels;
using Application.ItemPlaylist.Commands;
using Application.Playlists.ViewModels;
using Application.Usuarios.ViewModels;
using Application.Conteudos.ViewModels;
using Application.Criadores.ViewModels;

namespace Application.ItemitemPlaylist.Commands.Handlers;

public sealed class InsertItemPlaylistCommandHandler(IItemPlaylistService itemPlaylistService, ILogger<InsertItemPlaylistCommandHandler> logger) :
    BaseCommandHandler<InsertItemPlaylistCommand, InsertItemPlayListViewModel>(logger)
{
    private readonly IItemPlaylistService _itemPlaylistService = itemPlaylistService;
    protected override async Task<InsertItemPlayListViewModel> ExecuteAsync(InsertItemPlaylistCommand request, CancellationToken cancellationToken)
    {
        var itemPlaylist = await _itemPlaylistService.AdicionarItemPlaylist(request.PlaylistId, request.ConteudoId);

        return new InsertItemPlayListViewModel
        {
            Playlist = new PlaylistViewModel 
            { 
               Id = itemPlaylist.Playlist.Id, 
               Nome = itemPlaylist.Playlist.Nome,
               Usuario = new UsuarioViewModel
               {
                    Id = itemPlaylist.Playlist.Usuario.Id,
                    Nome = itemPlaylist.Playlist.Usuario.Nome,
                    Email = itemPlaylist.Playlist.Usuario.Email
               }
            },
            Conteudo = new ConteudoViewModel
            {
                Id = itemPlaylist.Conteudo.Id, 
                Titulo = itemPlaylist.Conteudo.Titulo, 
                Tipo = itemPlaylist.Conteudo.Tipo,
                Criador = new CriadorViewModel
                {
                    Id = itemPlaylist.Conteudo.Criador.Id,
                    Nome = itemPlaylist.Conteudo.Criador.Nome
                }
            }
        };
    }
}
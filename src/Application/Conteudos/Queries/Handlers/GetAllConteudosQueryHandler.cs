using Application.Common;
using Application.Conteudos.ViewModels;
using Application.Criadores.ViewModels;
using Microsoft.Extensions.Logging;
using Service.Interfaces;


namespace Application.Conteudos.Queries.Handlers;

public sealed class GetAllConteudosQueryHandler(IConteudoService conteudoService, ILogger<GetAllConteudosQueryHandler> logger) :
    BaseQueryHandler<GetAllConteudosQuery, IEnumerable<ConteudoViewModel>>(logger)
{
    private readonly IConteudoService _conteudoService = conteudoService;
    protected override async Task<IEnumerable<ConteudoViewModel>> ExecuteAsync(GetAllConteudosQuery request, CancellationToken cancellationToken)
    {
        var conteudos = await _conteudoService.ObterTodosConteudos();
        return conteudos.Select(conteudo => new ConteudoViewModel
        {
            Id = conteudo.Id,
            Titulo = conteudo.Titulo,
            Tipo = conteudo.Tipo,
            Criador = new CriadorViewModel
            {
                Id = conteudo.Criador.Id,
                Nome = conteudo.Criador.Nome,
            }
        });
    }
}

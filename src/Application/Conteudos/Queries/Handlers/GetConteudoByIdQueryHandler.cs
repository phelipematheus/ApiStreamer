using Application.Common;
using Application.Conteudos.ViewModels;
using Application.Criadores.ViewModels;
using Microsoft.Extensions.Logging;
using Service.Interfaces;

namespace Application.Conteudos.Queries.Handlers;

public sealed class GetConteudoByIdQueryHandler(IConteudoService conteudoService, ILogger<GetConteudoByIdQueryHandler> logger) :
    BaseQueryHandler<GetConteudoByIdQuery, ConteudoViewModel>(logger)
{
    private readonly IConteudoService _conteudoService = conteudoService;
    protected override async Task<ConteudoViewModel> ExecuteAsync(GetConteudoByIdQuery request, CancellationToken cancellationToken)
    {
        var conteudo = await _conteudoService.ObterConteudoPorId(request.Id);
        return new ConteudoViewModel
        {
            Id = conteudo.Id,
            Titulo = conteudo.Titulo,
            Tipo = conteudo.Tipo,
            Criador = new CriadorViewModel
            {
                Id = conteudo.Criador.Id,
                Nome = conteudo.Criador.Nome,
            }
        };
    }
}


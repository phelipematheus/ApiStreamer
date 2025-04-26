using Application.Common;
using Application.Conteudos.ViewModels;
using Application.Criadores.ViewModels;
using Microsoft.Extensions.Logging;
using Service.Interfaces;

namespace Application.Conteudos.Commands.Handlers;

public sealed class InsertConteudoCommandHandler(IConteudoService conteudoService, ILogger<InsertConteudoCommandHandler> logger) :
    BaseCommandHandler<InsertConteudoCommand, ConteudoViewModel>(logger)
{
    private readonly IConteudoService _conteudoService = conteudoService;
    protected override async Task<ConteudoViewModel> ExecuteAsync(InsertConteudoCommand request, CancellationToken cancellationToken)
    {
        var conteudo = await _conteudoService.AdicionarConteudo(request.Titulo, request.Tipo, request.CriadorId);

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

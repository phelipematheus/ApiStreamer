

using Application.Common;
using Application.Conteudos.ViewModels;
using Application.Criadores.ViewModels;
using Microsoft.Extensions.Logging;
using Service.Interfaces;

namespace Application.Conteudos.Commands.Handlers;

public sealed class UpdateConteudoCommandHandler(IConteudoService conteudoService, ILogger<UpdateConteudoCommandHandler> logger) :
    BaseCommandHandler<UpdateConteudoCommand, ConteudoViewModel>(logger)
{
    private readonly IConteudoService _conteudoService = conteudoService;
    protected override async Task<ConteudoViewModel> ExecuteAsync(UpdateConteudoCommand request, CancellationToken cancellationToken)
    {
        var conteudo = await _conteudoService.AtualizarConteudo(request.Id, request.Titulo, request.Tipo);
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

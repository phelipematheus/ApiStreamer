using Application.Common;
using Application.Criadores.ViewModels;
using Microsoft.Extensions.Logging;
using Service.Interfaces;

namespace Application.Criadores.Commands.Handlers;

public sealed class InsertCriadorCommandHandler(
    ICriadorService criadorService,
    ILogger<InsertCriadorCommandHandler> logger) : BaseCommandHandler<InsertCriadorCommand, CriadorViewModel>(logger)
{
    private readonly ICriadorService _criadorService = criadorService;
    protected override async Task<CriadorViewModel> ExecuteAsync(InsertCriadorCommand request, CancellationToken cancellationToken)
    {
        var criador = await _criadorService.AdicionarCriador(request.Nome);
        return new CriadorViewModel
        {
            Id = criador.Id,
            Nome = criador.Nome
        };
    }
}

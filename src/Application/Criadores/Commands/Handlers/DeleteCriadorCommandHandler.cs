using Application.Common;
using Application.Global.ViewModels;
using Microsoft.Extensions.Logging;
using Service.Interfaces;

namespace Application.Criadores.Commands.Handlers;

public sealed class DeleteCriadorCommandHandler(ICriadorService criadorService, ILogger<DeleteCriadorCommandHandler> logger) :
    BaseCommandHandler<DeleteCriadorCommand, DeleteViewModel>(logger)
{
    private readonly ICriadorService _criadorService = criadorService;
    protected override async Task<DeleteViewModel> ExecuteAsync(DeleteCriadorCommand request, CancellationToken cancellationToken)
    {
        await _criadorService.RemoverCriador(request.Id);
        return new DeleteViewModel(request.Id, "Criador removido com sucesso.");
    }
}

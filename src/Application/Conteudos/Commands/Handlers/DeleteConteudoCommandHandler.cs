using Application.Common;
using Application.Global.ViewModels;
using Microsoft.Extensions.Logging;
using Service.Interfaces;

namespace Application.Conteudos.Commands.Handlers;

public sealed class DeleteConteudoCommandHandler(IConteudoService conteudoService, ILogger<DeleteConteudoCommandHandler> logger) :
    BaseCommandHandler<DeleteConteudoCommand, DeleteViewModel>(logger)
{
    private readonly IConteudoService _conteudoService = conteudoService;
    protected override async Task<DeleteViewModel> ExecuteAsync(DeleteConteudoCommand request, CancellationToken cancellationToken)
    {
        await _conteudoService.RemoverConteudo(request.Id);
        return new DeleteViewModel(request.Id, "Conteúdo removido com sucesso.");
    }
}

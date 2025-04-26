using Application.Common;
using Application.Criadores.ViewModels;
using Microsoft.Extensions.Logging;
using Service.Interfaces;

namespace Application.Criadores.Commands.Handlers
{
    public sealed class UpdateCriadorCommandHandler(ICriadorService criadorService, ILogger<UpdateCriadorCommandHandler> logger) :
        BaseCommandHandler<UpdateCriadorCommand, CriadorViewModel>(logger)
    {
        private readonly ICriadorService _criadorService = criadorService;
        protected override async Task<CriadorViewModel> ExecuteAsync(UpdateCriadorCommand request, CancellationToken cancellationToken)
        {
            var criador = await _criadorService.AtualizarCriador(request.Id, request.Nome);
            return new CriadorViewModel
            {
                Id = criador.Id,
                Nome = criador.Nome
            };
        }
    }
}

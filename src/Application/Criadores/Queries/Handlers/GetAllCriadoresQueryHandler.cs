
using Application.Common;
using Application.Criadores.ViewModels;
using Microsoft.Extensions.Logging;
using Service.Interfaces;

namespace Application.Criadores.Queries.Handlers;

public sealed class GetAllCriadoresQueryHandler(ICriadorService criadorService, ILogger<GetAllCriadoresQueryHandler> logger) : 
    BaseQueryHandler<GetAllCriadoresQuery, IEnumerable<CriadorViewModel>>(logger)
{
    private readonly ICriadorService _criadorService = criadorService;
    protected override async Task<IEnumerable<CriadorViewModel>> ExecuteAsync(GetAllCriadoresQuery request, CancellationToken cancellationToken)
    {
        var criadores = await _criadorService.ObterTodosCriadores();
        return criadores.Select(criador => new CriadorViewModel
        {
            Id = criador.Id,
            Nome = criador.Nome
        });
    }
}

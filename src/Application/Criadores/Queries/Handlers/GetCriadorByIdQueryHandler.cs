using Application.Common;
using Application.Criadores.ViewModels;
using Microsoft.Extensions.Logging;
using Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Criadores.Queries.Handlers;

public sealed class GetCriadorByIdQueryHandler(
    ICriadorService criadorService,
    ILogger<GetCriadorByIdQueryHandler> logger) :
    BaseQueryHandler<GetCriadorByIdQuery, CriadorViewModel>(logger)
{
    private readonly ICriadorService _criadorService = criadorService;
    protected override async Task<CriadorViewModel> ExecuteAsync(GetCriadorByIdQuery request, CancellationToken cancellationToken)
    {
        var criador = await _criadorService.ObterCriadorPorId(request.Id);
        return new CriadorViewModel
        {
            Id = criador.Id,
            Nome = criador.Nome
        };
    }
}

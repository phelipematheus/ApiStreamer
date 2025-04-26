using Application.Interfaces;
using Microsoft.Extensions.Logging;

namespace Application.Common;

public abstract class BaseQueryHandler<TQuery, TResult>(ILogger<IQueryHandler<TQuery, TResult>> logger) : IQueryHandler<TQuery, TResult>
        where TQuery : IQuery<TResult>
{
    private readonly ILogger<IQueryHandler<TQuery, TResult>> _logger = logger;

    public async Task<TResult> Handle(TQuery request, CancellationToken cancellationToken)
    {
        LogAttempt(_logger, request);

        try
        {
            var result = await ExecuteAsync(request, cancellationToken);
            LogSuccess(_logger, request);
            return result;
        }
        catch
        {
            LogFailure(_logger);
            throw;
        }
    }

    protected abstract Task<TResult> ExecuteAsync(TQuery request, CancellationToken cancellationToken);

    private static void LogAttempt(ILogger logger, TQuery query)
    {
        logger.LogDebug("Tentativa de processar query: {QueryName} - Detalhes: {@Query}", typeof(TQuery).Name, query);
    }

    private static void LogSuccess(ILogger logger, TQuery query)
    {
        logger.LogDebug("Query processada com sucesso: {QueryName} - Detalhes: {@Query}", typeof(TQuery).Name, query);
    }

    private static void LogFailure(ILogger logger)
    {
        logger.LogError($"Falha ao processar query: {typeof(TQuery).Name}");
    }
}

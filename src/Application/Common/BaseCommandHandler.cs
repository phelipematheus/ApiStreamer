using Application.Interfaces;
using Microsoft.Extensions.Logging;

namespace Application.Common;

public abstract class BaseCommandHandler<TCommand, TResult>(ILogger<ICommandHandler<TCommand, TResult>> logger) : ICommandHandler<TCommand, TResult>
        where TCommand : ICommand<TResult>
{
    private readonly ILogger<ICommandHandler<TCommand, TResult>> _logger = logger;

    public async Task<TResult> Handle(TCommand request, CancellationToken cancellationToken)
    {
        BaseCommandHandler<TCommand, TResult>.LogAttempt(_logger, request);

        try
        {
            var result = await ExecuteAsync(request, cancellationToken);
            BaseCommandHandler<TCommand, TResult>.LogSuccess(_logger, request);
            return result;
        }
        catch
        {
            BaseCommandHandler<TCommand, TResult>.LogFailure(_logger);
            throw;
        }
    }

    protected abstract Task<TResult> ExecuteAsync(TCommand request, CancellationToken cancellationToken);

    private static void LogAttempt(ILogger logger, TCommand command)
    {
        logger.LogDebug("Tentativa de processar comando: {CommandName} - Detalhes: {@Command}", typeof(TCommand).Name, command);
    }

    private static void LogSuccess(ILogger logger, TCommand command)
    {
        logger.LogDebug("Comando processado com sucesso: {CommandName} - Detalhes: {@Command}", typeof(TCommand).Name, command);
    }

    private static void LogFailure(ILogger logger)
    {
        logger.LogError($"Falha ao processar comando: {typeof(TCommand).Name}");
    }
}

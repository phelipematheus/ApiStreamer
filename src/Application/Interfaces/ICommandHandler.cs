using MediatR;

namespace Application.Interfaces
{
    /// <summary>
    /// Interface ICommandHandler que define um manipulador de comandos.
    /// </summary>
    /// <typeparam name="TCommand">Tipo de comando que deve ser manipulado.</typeparam>
    /// <typeparam name="TResponse">Tipo de resposta que deve ser gerada quando o comando é manipulado.</typeparam>
    public interface ICommandHandler<in TCommand, TResponse> : IRequestHandler<TCommand, TResponse>
       where TCommand : ICommand<TResponse>
    {
    }
}

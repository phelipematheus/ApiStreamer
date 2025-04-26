using MediatR;

namespace Application.Interfaces
{
    /// <summary>
    /// Interface IQueryHandler que define um manipulador de consultas.
    /// </summary>
    /// <typeparam name="TQuery">Tipo de consulta que deve ser manipulada.</typeparam>
    /// <typeparam name="TResponse">Tipo de resposta que deve ser gerada quando a consulta é manipulada.</typeparam>
    public interface IQueryHandler<in TQuery, TResponse> : IRequestHandler<TQuery, TResponse>
        where TQuery : IQuery<TResponse>
    {
    }
}

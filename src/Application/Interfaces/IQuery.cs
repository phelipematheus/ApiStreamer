using MediatR;

namespace Application.Interfaces;

/// <summary>
/// Interface IQuery definindo uma consulta a ser executada pela aplicação.
/// </summary>
/// <typeparam name="TResponse">Tipo de resposta que deve ser gerada quando a consulta é executada.</typeparam>
public interface IQuery<out TResponse> : IRequest<TResponse>
{
}

using MediatR;

namespace Application.Interfaces
{
    /// <summary>
    /// Interface ICommand definindo um comando a ser executado pela aplicação.
    /// </summary>
    /// <typeparam name="TResponse">Tipo de resposta que deve ser gerado quando o comando é executado.</typeparam>
    public interface ICommand<out TResponse> : IRequest<TResponse>
    {
    }
}

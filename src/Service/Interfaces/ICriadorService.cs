using Domain.Interfaces;

namespace Service.Interfaces
{
    public interface ICriadorService
    {
        Task<ICriador> AdicionarCriador(string nome);
        Task<ICriador> AtualizarCriador(int criadorId, string nome);
        Task<ICriador> ObterCriadorPorId(int criadorId);
        Task<IEnumerable<ICriador>> ObterTodosCriadores();
        Task RemoverCriador(int criadorId);
    }
}

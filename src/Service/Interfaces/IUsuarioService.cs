using Domain.Interfaces;

namespace Service.Interfaces
{
    public interface IUsuarioService
    {
        Task<IUsuario> AdicionarUsuario(string nome, string email);
        Task<IUsuario> AtualizarUsuario(int id, string nome, string email);
        Task RemoverUsuario(int id);
        Task<IUsuario> ObterUsuarioPorId(int id);
        Task<IEnumerable<IUsuario>> ObterTodosUsuarios();
    }
}

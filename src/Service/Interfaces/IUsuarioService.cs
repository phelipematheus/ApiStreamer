using Domain.Interfaces;

namespace Service.Interfaces
{
    public interface IUsuarioService
    {
        Task<IUsuario> AdicionarUsuario(string nome, string email, string senha);
        Task<IUsuario> AtualizarUsuario(int id, string nome, string email, string senha);
        Task RemoverUsuario(int id);
        Task<IUsuario> ObterUsuarioPorId(int id);
        Task<IUsuario> ObterUsuarioPorEmail(string email);
        Task RecuperarSenha(string email, string novaSenha);
        Task<IEnumerable<IUsuario>> ObterTodosUsuarios();
    }
}

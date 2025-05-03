using Domain.Interfaces;

namespace Domain.Entities;
public class Usuario(string nome, string email, string senha) : Entity, IUsuario
{
    public string Nome { get; set; } = nome;
    public string Email { get; set; } = email;
    public string Senha { get; set; } = senha;
    public virtual IList<Playlist> Playlists { get; set; } = [];

    public void AtualizarDados(string nome, string email, string senha)
    {
        Nome = nome;
        Email = email;
        Senha = senha;
    }
    public void AtualizarSenha(string novaSenha)
    {
        Senha = novaSenha;
    }
}

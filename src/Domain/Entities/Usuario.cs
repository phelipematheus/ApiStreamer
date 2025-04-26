using Domain.Interfaces;

namespace Domain.Entities;
public class Usuario(string nome, string email) : Entity, IUsuario
{
    public string Nome { get; set; } = nome;
    public string Email { get; set; } = email;
    public virtual IList<Playlist> Playlists { get; set; } = [];

    public void AtualizarDados(string nome, string email)
    {
        Nome = nome;
        Email = email;
    }
}

using Domain.Entities;

namespace Domain.Interfaces;
public interface IPlaylist : IEntity
{
    string Nome { get; }
    int UsuarioId { get; }
    Usuario Usuario { get; }
    IList<Conteudo> Conteudos { get; }

    void AtualizarDados(string nome);
}

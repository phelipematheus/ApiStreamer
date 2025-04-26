using Domain.Entities;

namespace Domain.Interfaces;

public interface ICriador : IEntity
{
    string Nome { get; }
    IList<Conteudo> Conteudos { get; }

    void AtualizarDados(string nome);
}

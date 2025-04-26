using Domain.Interfaces;

namespace Domain.Entities;

public class Conteudo(string titulo, string tipo, int criadorId) : Entity, IConteudo
{
    public string Titulo { get; set; } = titulo;
    public string Tipo { get; set; } = tipo;
    public int CriadorId { get; set; } = criadorId;
    public virtual Criador Criador { get; set; } = default!;
    public virtual IList<Playlist> Playlists { get; set; } = [];

    public void AtualizarDados(string titulo, string tipo)
    {
        Titulo = titulo;
        Tipo = tipo;
    }
}

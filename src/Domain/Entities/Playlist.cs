using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Interfaces;

namespace Domain.Entities;
public class Playlist(string nome, int usuarioId) : Entity, IPlaylist
{
    public string Nome { get; set; } = nome;
    public int UsuarioId { get; set; } = usuarioId;
    public virtual Usuario Usuario { get; set; } = default!;
    public virtual IList<Conteudo> Conteudos { get; set; } = new List<Conteudo>();

    public void AtualizarDados(string nome)
    {
        Nome = nome;
    }
}

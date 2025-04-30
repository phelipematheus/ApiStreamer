using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces;
public interface IUsuario : IEntity
{
    string Nome { get; }
    string Email { get; }
    string Senha { get; }
    IList<Playlist> Playlists { get; }
    void AtualizarDados(string nome, string email, string senha);
}

using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces;

public interface IConteudo : IEntity
{
    string Titulo { get; }
    string Tipo { get; }
    int CriadorId { get; }
    Criador Criador { get; }
    IList<Playlist> Playlists { get; }

    void AtualizarDados(string titulo, string tipo);
}

using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;

public class Criador(string nome) : Entity, ICriador
{
    public string Nome { get; set; } = nome;
    public virtual IList<Conteudo> Conteudos { get; set; } = [];

    public void AtualizarDados (string nome)
    {
        Nome = nome;
    }
}

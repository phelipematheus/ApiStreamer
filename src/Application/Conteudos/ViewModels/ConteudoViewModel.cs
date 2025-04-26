using Application.Criadores.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Conteudos.ViewModels;

public record ConteudoViewModel
{
    public int Id { get; set; }
    public string Titulo { get; set; } = string.Empty;
    public string Tipo { get; set; } = string.Empty;
    public CriadorViewModel Criador { get; set; } = new();

}

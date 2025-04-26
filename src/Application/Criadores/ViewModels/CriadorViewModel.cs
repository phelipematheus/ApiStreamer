using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Criadores.ViewModels;

public sealed record CriadorViewModel()
{
    public int Id { get; set; }
    public string Nome { get; set; } = string.Empty;
}

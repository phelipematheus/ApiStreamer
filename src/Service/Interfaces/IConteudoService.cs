using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interfaces;

public interface IConteudoService
{
    Task<IConteudo> AdicionarConteudo(string titulo, string tipo, int criadorId);
    Task<IConteudo> AtualizarConteudo(int conteudoId, string titulo, string tipo);
    Task<IConteudo> ObterConteudoPorId(int conteudoId);
    Task<IEnumerable<IConteudo>> ObterTodosConteudos();
    Task RemoverConteudo(int conteudoId);
}

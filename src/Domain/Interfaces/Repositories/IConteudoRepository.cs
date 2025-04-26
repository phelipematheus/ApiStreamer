using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.Repositories;

public interface IConteudoRepository : IRepository
{
    IConteudo GetConteudoById(int id);
    IList<IConteudo> GetAllConteudos();
    void AddConteudo(IConteudo conteudo);
    void UpdateConteudo(IConteudo conteudo);
    void DeleteConteudo(int id);
}

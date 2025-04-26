using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.Repositories
{
    public interface ICriadorRepository : IRepository
    {
        ICriador GetCriadorById(int id);
        IList<ICriador> GetAllCriadores();
        void AddCriador(ICriador Criador);
        void UpdateCriador(ICriador Criador);
        void DeleteCriador(int id);
    }
}

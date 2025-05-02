using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.Repositories
{
    public interface IUsuarioRepository : IRepository
    {
        IUsuario GetUsuarioById(int id);
        IUsuario GetUsuarioByEmail(string email);
        IList<IUsuario> GetAllUsuarios();
        void AddUsuario(IUsuario usuario);
        void UpdateUsuario(IUsuario usuario);
        void DeleteUsuario(int id);
    }
}

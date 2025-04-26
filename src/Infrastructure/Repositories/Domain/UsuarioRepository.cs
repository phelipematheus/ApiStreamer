using Domain.Entities;
using Domain.Interfaces;
using Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories.Domain
{
    public class UsuarioRepository(StreamerDbContext dbContext) : RepositoryBase(dbContext), IUsuarioRepository
    {
        private readonly StreamerDbContext _dbContext = dbContext;

        public IUsuario GetUsuarioById(int id)
        {
            return _dbContext.Usuarios
                .FirstOrDefault(u => u.Id == id)!;
        }

        public IList<IUsuario> GetAllUsuarios()
        {
            return _dbContext.Usuarios
                .Cast<IUsuario>()
                .ToList();
        }

        public void AddUsuario(IUsuario usuario)
        {
            _dbContext.Usuarios.Add((Usuario)usuario);
        }

        public void UpdateUsuario(IUsuario usuario)
        {
            foreach (var entry in _dbContext.ChangeTracker.Entries())
            {
                if (entry.Entity is Usuario && entry.State == EntityState.Modified)
                {
                    bool isModified = entry.OriginalValues.Properties
                        .Any(p => !Equals(entry.CurrentValues[p], entry.OriginalValues[p]));

                    if (!isModified)
                    {
                        entry.State = EntityState.Unchanged;
                    }
                }
            }

            _dbContext.Usuarios.Update((Usuario)usuario);
        }

        public void DeleteUsuario(int id)
        {
            var usuario = _dbContext.Usuarios.Find(id);
            if (usuario is not null)
            {
                _dbContext.Usuarios.Remove((Usuario)usuario);
            }
        }
    }
}

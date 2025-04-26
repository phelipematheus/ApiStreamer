using Domain.Entities;
using Domain.Interfaces;
using Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories.Domain;
public class CriadorRepository(StreamerDbContext dbContext) : RepositoryBase(dbContext), ICriadorRepository
{
    private readonly StreamerDbContext _dbContext = dbContext;

    public ICriador GetCriadorById(int id)
    {
        return _dbContext.Criadores
            .FirstOrDefault(c => c.Id == id)!;
    }

    public IList<ICriador> GetAllCriadores()
    {
        return _dbContext.Criadores
            .Cast<ICriador>()
            .ToList();
    }

    public void AddCriador(ICriador criador)
    {
        _dbContext.Criadores.Add((Criador)criador);
    }

    public void UpdateCriador(ICriador criador)
    {
        foreach (var entry in _dbContext.ChangeTracker.Entries())
        {
            if (entry.Entity is Criador && entry.State == EntityState.Modified)
            {
                bool isModified = entry.OriginalValues.Properties
                    .Any(p => !Equals(entry.CurrentValues[p], entry.OriginalValues[p]));

                if (!isModified)
                {
                    entry.State = EntityState.Unchanged;
                }
            }
        }

        _dbContext.Criadores.Update((Criador)criador);
    }

    public void DeleteCriador(int id)
    {
        var criador = _dbContext.Criadores.Find(id);
        if (criador is not null)
        {
            _dbContext.Criadores.Remove((Criador)criador);
        }
    }
}


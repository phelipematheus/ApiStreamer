using Domain.Entities;
using Domain.Interfaces.Repositories;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.Domain;

public class ConteudoRepository(StreamerDbContext dbContext) : RepositoryBase(dbContext), IConteudoRepository
{
    private readonly StreamerDbContext _dbContext = dbContext;

    public IConteudo GetConteudoById(int id)
    {
        return _dbContext.Conteudos
            .Include(p => p.Criador)
            .FirstOrDefault(p => p.Id == id)!;
    }

    public IList<IConteudo> GetAllConteudos()
    {
        return _dbContext.Conteudos
            .Include(p => p.Criador)
            .Cast<IConteudo>()
            .ToList();
    }

    public void AddConteudo(IConteudo conteudo)
    {
        _dbContext.Conteudos.Add((Conteudo)conteudo);
    }

    public void UpdateConteudo(IConteudo conteudo)
    {
        foreach (var entry in _dbContext.ChangeTracker.Entries())
        {
            if (entry.Entity is Conteudo && entry.State == EntityState.Modified)
            {
                bool isModified = entry.OriginalValues.Properties
                    .Any(p => !Equals(entry.CurrentValues[p], entry.OriginalValues[p]));

                if (!isModified)
                {
                    entry.State = EntityState.Unchanged;
                }
            }
        }

        _dbContext.Conteudos.Update((Conteudo)conteudo);
    }

    public void DeleteConteudo(int id)
    {
        var conteudo = _dbContext.Conteudos.Find(id);
        if (conteudo is not null)
        {
            _dbContext.Conteudos.Remove((Conteudo)conteudo);
        }
    }
}

using Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.Domain;
public abstract class RepositoryBase(StreamerDbContext dbContext) : IRepository
{
    public async Task<bool> SaveChanges()
    {
        var result = await dbContext.SaveChangesAsync();
        return result > 0;
    }
}

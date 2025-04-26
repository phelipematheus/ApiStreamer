namespace Domain.Interfaces.Repositories;
public interface IRepository
{
    Task<bool> SaveChanges();
}

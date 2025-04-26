using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.Query;
public class QueryRepository<T> : IQueryRepository<T> where T : class
{
    private readonly StreamerDbContext _context;

    public QueryRepository(StreamerDbContext context)
    {
        _context = context;
    }

    public async Task<T?> GetAsync(ISpecification<T> spec, CancellationToken cancellationToken = default)
    {
        return await ApplySpecification(spec).FirstOrDefaultAsync(cancellationToken);
    }

    public async Task<TResult?> GetAsync<TResult>(ISelectSpecification<T, TResult> spec, CancellationToken cancellationToken = default)
    {
        return await ApplySpecification(spec).FirstOrDefaultAsync(cancellationToken);
    }

    public async Task<IEnumerable<T>> ListAsync(ISpecification<T> spec, CancellationToken cancellationToken = default)
    {
        return await ApplySpecification(spec).ToListAsync(cancellationToken);
    }

    public async Task<IEnumerable<TResult>> ListAsync<TResult>(ISelectSpecification<T, TResult> spec, CancellationToken cancellationToken = default)
    {
        return await ApplySpecification(spec).ToListAsync(cancellationToken);
    }

    private IQueryable<T> ApplySpecification(ISpecification<T> spec)
    {
        var query = _context.Set<T>().AsQueryable();

        if (spec.Criteria != null)
        {
            query = query.Where(spec.Criteria);
        }

        if (spec.OrderBy != null)
        {
            query = query.OrderBy(spec.OrderBy);
        }
        else if (spec.OrderByDescending != null)
        {
            query = query.OrderByDescending(spec.OrderByDescending);
        }

        query = spec.Includes.Aggregate(query, (current, include) => current.Include(include));

        return query;
    }

    private IQueryable<TResult> ApplySpecification<TResult>(ISelectSpecification<T, TResult> spec)
    {
        var query = _context.Set<T>().AsQueryable();

        if (spec.Criteria != null)
        {
            query = query.Where(spec.Criteria);
        }

        if (spec.OrderBy != null)
        {
            query = query.OrderBy(spec.OrderBy);
        }
        else if (spec.OrderByDescending != null)
        {
            query = query.OrderByDescending(spec.OrderByDescending);
        }

        query = spec.Includes.Aggregate(query, (current, include) => current.Include(include));

        return query.Select(spec.Selector);
    }
}

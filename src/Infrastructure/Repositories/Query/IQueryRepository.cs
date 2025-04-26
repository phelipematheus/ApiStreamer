namespace Infrastructure.Repositories.Query
{
    public interface IQueryRepository<T> where T : class
    {
        Task<IEnumerable<T>> ListAsync(ISpecification<T> spec, CancellationToken cancellationToken = default);
        Task<T?> GetAsync(ISpecification<T> spec, CancellationToken cancellationToken = default);

        Task<IEnumerable<TResult>> ListAsync<TResult>(ISelectSpecification<T, TResult> spec, CancellationToken cancellationToken = default);
        Task<TResult?> GetAsync<TResult>(ISelectSpecification<T, TResult> spec, CancellationToken cancellationToken = default);
    }
}

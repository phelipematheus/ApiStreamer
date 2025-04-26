using System.Linq.Expressions;

namespace Infrastructure.Repositories.Query;

public interface ISelectSpecification<T, TResult> : ISpecification<T>
{
    Expression<Func<T, TResult>> Selector { get; }
}

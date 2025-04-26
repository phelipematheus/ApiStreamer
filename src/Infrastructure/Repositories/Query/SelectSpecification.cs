using System.Linq.Expressions;

namespace Infrastructure.Repositories.Query;
public abstract class SelectSpecification<T, Result>(Expression<Func<T, bool>> criteria) : Specification<T>(criteria), ISelectSpecification<T, Result>
{
    public abstract Expression<Func<T, Result>> Selector { get; }
}

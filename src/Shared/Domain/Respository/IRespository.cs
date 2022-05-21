using System.Linq.Expressions;

namespace Kusuri.Shared.Domain.Respository;

public interface IRepository<TEntity, in TKey> where TEntity : class {
    Task Save(TEntity entity);
    Task<TEntity?> Find(TKey key, bool noTracking);
    Task<TEntity?> Find(TKey key);
    Task<bool> Any(Expression<Func<TEntity, bool>> predicate);
    Task Delete(TEntity entity);
}
    

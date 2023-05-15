using System.Linq.Expressions;

namespace Practice.Hangman.Core.Abstractions.Repositories;

public interface IRepository<TEntity, TIdentifier> where TEntity : class where TIdentifier : struct
{
    Task<TEntity?> GetById(TIdentifier id);
    Task<ICollection<TEntity>> GetAll(Expression<Func<TEntity, bool>>? condition = null);
    Task<TEntity> CreateAsync(TEntity entity);    
    Task<TEntity> UpdateAsync(TEntity entity);
    Task<bool> DeleteAsync(TIdentifier id);
}

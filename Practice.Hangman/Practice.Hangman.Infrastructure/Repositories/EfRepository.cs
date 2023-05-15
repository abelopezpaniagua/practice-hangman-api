using Microsoft.EntityFrameworkCore;
using Practice.Hangman.Core.Abstractions.Repositories;
using Practice.Hangman.Domain.Entities;
using Practice.Hangman.Infrastructure.Data;
using System.Linq.Expressions;

namespace Practice.Hangman.Infrastructure.Repositories;

public abstract class EfRepository<TEntity, TIdentifier> : IRepository<TEntity, TIdentifier> where TEntity : class, IIdentifiable<TIdentifier> where TIdentifier : struct
{
    protected readonly GameDbContext _dbContext;

    protected EfRepository(GameDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public virtual async Task<TEntity> CreateAsync(TEntity entity)
    {
        var entryCreated = await _dbContext.Set<TEntity>()
            .AddAsync(entity);

        await _dbContext.SaveChangesAsync();

        return entryCreated.Entity;
    }

    public virtual async Task<bool> DeleteAsync(TIdentifier id)
    {
        var affectedRows = await _dbContext.Set<TEntity>()
            .Where(x => x.Id.Equals(id))
            .ExecuteDeleteAsync();

        return affectedRows > 0;
    }

    public virtual async Task<ICollection<TEntity>> GetAll(Expression<Func<TEntity, bool>>? condition = null)
    {
        var query = _dbContext.Set<TEntity>()
            .AsNoTracking();

        if (condition is not null)
        {
            query = query.Where(condition);
        }

        return await query.ToListAsync();
    }

    public virtual async Task<TEntity?> GetById(TIdentifier id)
    {
        return await _dbContext.Set<TEntity>()
            .FirstOrDefaultAsync(x => x.Id.Equals(id));
    }

    public virtual async Task<TEntity> UpdateAsync(TEntity entity)
    {
        var updatedEntry = _dbContext.Set<TEntity>()
            .Update(entity);

        await _dbContext.SaveChangesAsync();

        return updatedEntry.Entity;
    }
}

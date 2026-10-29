using Microsoft.EntityFrameworkCore;
using ToDo.Core.Entities.Base;

namespace ToDo.Data.Repositories;

public abstract class GenericRepository<TEntity, TId>
    where TEntity : BaseEntity<TId>
    where TId : struct
{
    protected readonly ApplicationDbContext _context;
    protected readonly DbSet<TEntity> _dbSet;

    protected GenericRepository(ApplicationDbContext context)
    {
        _context = context;
        _dbSet = context.Set<TEntity>();
    }

    public virtual async Task<List<TEntity>> GetAllAsync()
    {
        return await _dbSet.ToListAsync();
    }

    public virtual async Task<TEntity?> GetByIdAsync(TId id)
    {
        return await _dbSet.FirstOrDefaultAsync(x => x.Id.Equals(id));
    }

    public virtual async Task<TEntity> CreateAsync(TEntity entity)
    {
        entity.CreatedOn = DateTime.UtcNow;

        await _dbSet.AddAsync(entity);

        await _context.SaveChangesAsync();

        return entity;
    }

    public virtual async Task UpdateAsync(TEntity entity)
    {
        entity.UpdatedOn = DateTime.UtcNow;

        await _context.SaveChangesAsync();
    }

    public virtual async Task DeleteAsync(TId id)
    {
        var entity = await GetByIdAsync(id);
        if (entity == null)
            return;

        entity.IsDeleted = true;
        entity.DeletedOn = DateTime.UtcNow;

        await _context.SaveChangesAsync();
    }
}
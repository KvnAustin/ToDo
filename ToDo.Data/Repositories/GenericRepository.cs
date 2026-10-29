using Microsoft.EntityFrameworkCore;
using ToDo.Core.Entities.Base;

namespace ToDo.Data.Repositories;

public class GenericRepository<TEntity, TId>
    where TEntity : BaseEntity<TId>
    where TId : struct
{
    protected readonly ApplicationDbContext Context;
    protected readonly DbSet<TEntity> DbSet;

    public GenericRepository(ApplicationDbContext context)
    {
        this.Context = context;
        this.DbSet = context.Set<TEntity>();
    }

    public async Task<List<TEntity>> GetAllAsync()
    {
        return await DbSet.ToListAsync();
    }

    public async Task<TEntity?> GetByIdAsync(TId id)
    {
        return await DbSet.FirstOrDefaultAsync(x => x.Id.Equals(id));
    }

    public async Task<TEntity> CreateAsync(TEntity entity)
    {
        entity.CreatedOn = DateTime.UtcNow;

        await DbSet.AddAsync(entity);

        await Context.SaveChangesAsync();

        return entity;
    }

    public async Task UpdateAsync(TEntity entity)
    {
        entity.UpdatedOn = DateTime.UtcNow;

        DbSet.Update(entity);

        await Context.SaveChangesAsync();
    }

    public async Task DeleteAsync(TId id)
    {
        var entity = await GetByIdAsync(id);
        if (entity == null)
            return;

        entity.IsDeleted = true;
        entity.DeletedOn = DateTime.UtcNow;

        await Context.SaveChangesAsync();
    }
}
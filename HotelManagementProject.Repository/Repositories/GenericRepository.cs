using HotelManagementProject.DataAccess.AppDbContextFile;
using HotelManagementProject.Domain.Entites;
using HotelManagementProject.Domain.Intefacies;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace HotelManagementProject.Repository.Repositories;

public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
{
    private readonly AppDbContext _dbContext;

    protected readonly DbSet<T> Entities;

    public GenericRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
        Entities = _dbContext.Set<T>();
    }

    public async Task<bool> AddAsync(T entity)
    {
      var entry=  await Entities.AddAsync(entity);

        return entry.State==EntityState.Added;
    }

    public async Task<List<TResult>> QueryAsync<TResult>(Expression<Func<T, TResult>> selector, bool tracking = false)
    {
        var query = Entities.AsQueryable();

        if (!tracking)
            query = query.AsNoTracking();

        return await query.Select(selector).ToListAsync();
    }
    public async Task<bool> AnyAsync(Expression<Func<T, bool>> selector, bool tracking = false)
    {
        var query = Entities.AsQueryable();

        if (!tracking)
            query = query.AsNoTracking();

        return await query.AnyAsync(selector);
    }

    public async Task<T?> GetByIdAsync(Guid id, bool tracking = false)
    {
        var query = Entities.AsQueryable();

        if (!tracking)
            query = query.AsNoTracking();

        return await Entities.FindAsync(id);
    }

    public async Task<bool> SoftDeleteAsync(Guid id)
    {
        var entity = await Entities.FindAsync(id);

        if (entity == null)
            return false;

         entity.Delete();

        return true;
    }

    public async Task<bool> UpdateAsync(T entity)
    {
        entity.Update();

       var entry= Entities.Update(entity);

        return entry.State==EntityState.Modified;
    }
}

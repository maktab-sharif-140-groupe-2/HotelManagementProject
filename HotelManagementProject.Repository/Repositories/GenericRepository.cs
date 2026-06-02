using HotelManagementProject.DataAccess.AppDbContextFile;
using HotelManagementProject.Domain.Abstraction;
using HotelManagementProject.Domain.Intefacies;
using Microsoft.EntityFrameworkCore;

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
        await Entities.AddAsync(entity);

        return await _dbContext.SaveChangesAsync() > 0;
    }

    public async Task<List<T>> GetAllAsync(bool tracking = false)
    {
        var query = Entities.AsQueryable();

        if (!tracking)
            query = query.AsNoTracking();

        return await query.ToListAsync();
    }

    public async Task<T?> GetByIdAsync(int id, bool tracking = false)
    {
        var query = Entities.AsQueryable();

        if (!tracking)
            query = query.AsNoTracking();

        return await Entities.FindAsync(id);
    }

    public async Task<bool> SoftDeleteAsync(int id)
    {
        var entity = await Entities.FindAsync(id);

        if (entity == null)
            return false;

        entity.Delete();

        return await _dbContext.SaveChangesAsync() > 0;
    }

    public async Task<bool> UpdateAsync(T entity)
    {
        entity.Update();

        Entities.Update(entity);

        return await _dbContext.SaveChangesAsync() > 0;
    }
}

using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using VehicleMonitoring.Core.Domain.Models;
using VehicleMonitoring.Core.Repositories;

namespace VehicleMonitoring.Infrastructure.Repositories;

public class GenericRepository<T>(MonitoringDbContext context) : IRepository<T>
    where T : BaseEntity
{
    private readonly DbSet<T> _dbSet = context.Set<T>();

    public async Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, object>> include)
    {
        return await _dbSet.AsNoTracking().Include(include).ToListAsync(); 
    }

    public async Task<IEnumerable<T>> GetAllAsync()
    {
        return await _dbSet.AsNoTracking().ToListAsync();
    }

    public async Task<T?> GetAsync(Guid id, Expression<Func<T, object>> include)
    {
        return await _dbSet.Where(e=>e.Id.Equals(id)).Include(include).FirstOrDefaultAsync(); 
    }
}
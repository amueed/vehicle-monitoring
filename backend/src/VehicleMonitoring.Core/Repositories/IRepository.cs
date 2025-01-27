using System.Linq.Expressions;
using VehicleMonitoring.Core.Domain.Models;

namespace VehicleMonitoring.Core.Repositories;

public interface IRepository<T> where T : BaseEntity
{
    Task<IEnumerable<T>> GetAllAsync();
    Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, object>> include);
    Task<T?> GetAsync(Guid id, Expression<Func<T, object>> include);
}
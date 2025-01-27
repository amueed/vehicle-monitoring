using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using VehicleMonitoring.Core.Application;
using VehicleMonitoring.Core.Repositories;
using VehicleMonitoring.Infrastructure.Repositories;

namespace VehicleMonitoring.Infrastructure;

public static class DependencyInjections
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddDbContext<MonitoringDbContext>(options =>
            options.UseInMemoryDatabase("MonitoringDb"));
        
        services.AddScoped(typeof(IRepository<>), typeof(GenericRepository<>));
        services.AddScoped<IVehicleStatusService, VehicleStatusService>();
        return services;
    }
}
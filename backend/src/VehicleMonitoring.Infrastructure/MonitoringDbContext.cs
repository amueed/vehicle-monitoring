using Microsoft.EntityFrameworkCore;
using VehicleMonitoring.Core.Domain.Models;

namespace VehicleMonitoring.Infrastructure;

public class MonitoringDbContext(DbContextOptions<MonitoringDbContext> options) : DbContext(options)
{
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Vehicle> Vehicles { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        Guid c1 = Guid.NewGuid();
        Guid c2 = Guid.NewGuid();
        Guid c3 = Guid.NewGuid();
        
        modelBuilder.Entity<Customer>().HasData(
            new Customer { Id = c1, Name = "Kalles Grustransporter AB", Address = "Cementvägen 8, 111 11 Södertälje" },
            new Customer { Id = c2, Name = "Johans Bulk AB", Address = "Balkvägen 12, 222 22 Stockholm" },
            new Customer { Id = c3, Name = "Haralds Värdetransporter AB", Address = "Budgetvägen 1, 333 33 Uppsala" }
        );

        Guid v1 = Guid.NewGuid();
        Guid v2 = Guid.NewGuid();
        Guid v3 = Guid.NewGuid();
        Guid v4 = Guid.NewGuid();
        Guid v5 = Guid.NewGuid();
        Guid v6 = Guid.NewGuid();
        Guid v7 = Guid.NewGuid();
        
        modelBuilder.Entity<Vehicle>().HasData(
            new Vehicle { Id = v1, Vin = "YS2R4X20005399401", RegistrationNumber = "ABC123", CustomerId = c1 },
            new Vehicle { Id = v2, Vin = "VLUR4X20009093588", RegistrationNumber = "DEF456", CustomerId = c1 },
            new Vehicle { Id = v3, Vin = "VLUR4X20009048066", RegistrationNumber = "GHI789", CustomerId = c1 },
            new Vehicle { Id = v4, Vin = "YS2R4X20005388011", RegistrationNumber = "JKL012", CustomerId = c2 },
            new Vehicle { Id = v5, Vin = "YS2R4X20005387949", RegistrationNumber = "MNO345", CustomerId = c2 },
            new Vehicle { Id = v6, Vin = "YS2R4X20005387765", RegistrationNumber = "PQR678", CustomerId = c3 },
            new Vehicle { Id = v7, Vin = "YS2R4X20005387055", RegistrationNumber = "STU901", CustomerId = c3 }
        );
        base.OnModelCreating(modelBuilder);
    }
}
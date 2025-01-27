using VehicleMonitoring.Core.Domain.Models;

namespace VehicleMonitoring.Infrastructure;

public static class DatabaseSeeder
{
    // Seed Data Function
    public static void Seed(MonitoringDbContext context)
    {
        if (!context.Customers.Any())
        {
            Guid c1 = Guid.NewGuid();
            Guid c2 = Guid.NewGuid();
            Guid c3 = Guid.NewGuid();

            Guid v1 = Guid.NewGuid();
            Guid v2 = Guid.NewGuid();
            Guid v3 = Guid.NewGuid();
            Guid v4 = Guid.NewGuid();
            Guid v5 = Guid.NewGuid();
            Guid v6 = Guid.NewGuid();
            Guid v7 = Guid.NewGuid();

            var customers = new List<Customer>
            {
                new() { Id = c1, Name = "Kalles Grustransporter AB", Address = "Cementvägen 8, 111 11 Södertälje" },
                new() { Id = c2, Name = "Johans Bulk AB", Address = "Balkvägen 12, 222 22 Stockholm" },
                new() { Id = c3, Name = "Haralds Värdetransporter AB", Address = "Budgetvägen 1, 333 33 Uppsala" }
            };

            var vehicles = new List<Vehicle>
            {
                new() { Id = v1, Vin = "YS2R4X20005399401", RegistrationNumber = "ABC123", CustomerId = c1 },
                new() { Id = v2, Vin = "VLUR4X20009093588", RegistrationNumber = "DEF456", CustomerId = c1 },
                new() { Id = v3, Vin = "VLUR4X20009048066", RegistrationNumber = "GHI789", CustomerId = c1 },
                new() { Id = v4, Vin = "YS2R4X20005388011", RegistrationNumber = "JKL012", CustomerId = c2 },
                new() { Id = v5, Vin = "YS2R4X20005387949", RegistrationNumber = "MNO345", CustomerId = c2 },
                new() { Id = v6, Vin = "YS2R4X20005387765", RegistrationNumber = "PQR678", CustomerId = c3 },
                new() { Id = v7, Vin = "YS2R4X20005387055", RegistrationNumber = "STU901", CustomerId = c3 }
            };

            context.Customers.AddRange(customers);
            context.Vehicles.AddRange(vehicles);
            context.SaveChanges();
        }
    }
}
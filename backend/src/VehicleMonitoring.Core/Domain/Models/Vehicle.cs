namespace VehicleMonitoring.Core.Domain.Models;

public class Vehicle : BaseEntity
{
    public string Vin { get; set; }
    public string RegistrationNumber { get; set; }
    public Guid CustomerId { get; set; }
    public Customer Customer { get; set; }
}
namespace VehicleMonitoring.Core.Domain.Models;

public class Customer : BaseEntity
{
    public string Name { get; set; }
    public string Address { get; set; }
    public ICollection<Vehicle> Vehicles { get; set; }
}
using VehicleMonitoring.Core.Domain.Models;

namespace VehicleMonitoring.Api.ViewModels;

public class VehicleViewModel(Guid id, string vin, string registrationNumber, string status)
{
    public Guid Id { get; } = id;
    public string Vin { get; } = vin;
    public string RegistrationNumber { get; } = registrationNumber;
    public string Status { get; } = status;

    public static VehicleViewModel Create(Vehicle vehicle, string status)
    {
        ArgumentNullException.ThrowIfNull(vehicle);
        return new VehicleViewModel(vehicle.Id, vehicle.Vin, vehicle.RegistrationNumber, status);
    }
}
namespace VehicleMonitoring.Core.Application;

public interface IVehicleStatusService
{
    string GetStatus(Guid vehicleId);
}
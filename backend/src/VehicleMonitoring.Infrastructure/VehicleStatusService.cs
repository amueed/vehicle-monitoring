using VehicleMonitoring.Core.Application;

namespace VehicleMonitoring.Infrastructure;

public class VehicleStatusService : IVehicleStatusService
{
    private string[] statues =
    [
        "online", "offline"
    ];

    public string GetStatus(Guid vehicleId)
    {
        return statues[Random.Shared.Next(statues.Length)];
    }
}
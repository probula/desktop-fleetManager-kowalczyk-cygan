using ReactiveUI;
using ReactiveUI.Fody.Helpers;

namespace FleetManager.Models;

public enum VehicleStatus
{
    Available, //0
    InRoute, //1
    Service //2
}



public class Vehicle : ReactiveObject
{
    [Reactive] 
    public string Name { get; set; } = string.Empty;

    [Reactive] 
    public string LicensePlate { get; set; } = string.Empty;

    [Reactive] 
    public double FuelLevel { get; set; }

    [Reactive] 
    public VehicleStatus Status { get; set; }
}
using ReactiveUI;

namespace FleetManager.Models;

public enum VehicleStatus
{
    Available,
    InRoute,
    Service
}


public class Vehicle : ReactiveObject
{
    private string _name = string.Empty;
    private string _licensePlate = string.Empty;
    private double _fuelLevel;
    private VehicleStatus _status;

    public string Name 
    { 
        get => _name; 
        set => this.RaiseAndSetIfChanged(ref _name, value); 
    }

    public string LicensePlate 
    { 
        get => _licensePlate; 
        set => this.RaiseAndSetIfChanged(ref _licensePlate, value); 
    }

   
    public double FuelLevel 
    { 
        get => _fuelLevel; 
        set => this.RaiseAndSetIfChanged(ref _fuelLevel, value); 
    }

    //0 - available, 1 - InRoute, 2 - Service
    public VehicleStatus Status 
    { 
        get => _status; 
        set => this.RaiseAndSetIfChanged(ref _status, value); 
    }
}
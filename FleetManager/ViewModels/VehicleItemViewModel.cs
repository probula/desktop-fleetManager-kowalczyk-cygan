using System;
using System.Reactive;
using FleetManager.Models;
using ReactiveUI;

namespace FleetManager.ViewModels;

public class VehicleItemViewModel : ViewModelBase
{
    private readonly Vehicle _vehicle;
    private readonly Action _onChanged; 

    public ReactiveCommand<Unit, Unit> RefuelCommand { get; }
    public ReactiveCommand<Unit, Unit> GoOnRouteCommand { get; }

    public VehicleItemViewModel(Vehicle vehicle, Action onChanged)
    {
        _vehicle = vehicle;
        _onChanged = onChanged;
        
        var canRefuel = _vehicle.WhenAnyValue(
            x => x.Status,
            status => status != VehicleStatus.InRoute && status != VehicleStatus.Service);
        
        var canGoOnRoute = _vehicle.WhenAnyValue(
            x => x.FuelLevel,
            x => x.Status,
            (fuel, status) => fuel < 15 && status == VehicleStatus.Available);
        
        RefuelCommand = ReactiveCommand.Create(ExecuteRefuel, canRefuel);
        GoOnRouteCommand = ReactiveCommand.Create(ExecuteGoOnRoute, canGoOnRoute);
        
        _vehicle.WhenAnyValue(x => x.FuelLevel)
            .Subscribe(_ =>
            {
                this.RaisePropertyChanged(nameof(FuelLevel));
                this.RaisePropertyChanged(nameof(FuelColor));
            });

        _vehicle.WhenAnyValue(x => x.Status)
            .Subscribe(_ => this.RaisePropertyChanged(nameof(Status)));
        
    }
    
    public Vehicle GetVehicle() => _vehicle;

    public string Name => _vehicle.Name;
    public string LicensePlate => _vehicle.LicensePlate;
    public double FuelLevel => _vehicle.FuelLevel;
    public VehicleStatus Status => _vehicle.Status;
    
    public string FuelColor => FuelLevel switch
    {
        < 10 => "Red",      
        < 30 => "Orange",   
        _    => "Green"     
    };

    private void ExecuteRefuel()
    {
        _vehicle.FuelLevel = 100.0;
        Console.WriteLine("Refuel clicked!");
        _onChanged?.Invoke(); 
    }

    private void ExecuteGoOnRoute()
    {
        _vehicle.Status = VehicleStatus.InRoute;
        _onChanged?.Invoke(); 
    }
}
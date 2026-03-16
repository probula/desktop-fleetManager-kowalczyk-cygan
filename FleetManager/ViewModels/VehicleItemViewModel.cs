// (ViewModel dla UserControl)

using FleetManager.Models;
using FleetManager.Services;

namespace FleetManager.ViewModels;

public class VehicleItemViewModel : ViewModelBase
{
    private readonly Vehicle _vehicle;

    public  VehicleItemViewModel(Vehicle vehicle)
    {
        _vehicle = vehicle;
    }
    
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

}
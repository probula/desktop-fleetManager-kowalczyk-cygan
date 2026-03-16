using System;
using System.Collections.ObjectModel;
using FleetManager.Models;
using FleetManager.Services;

namespace FleetManager.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    private readonly IVehicleService _vehicleService;

    public ObservableCollection<VehicleItemViewModel> Vehicles { get; } = new();

    public MainWindowViewModel()
    {
        _vehicleService = new JsonVehicleService();

        LoadVehicles();
    }

    private async void LoadVehicles()
    {
        var vehicles = await _vehicleService.LoadVehicleAsync();

        Vehicles.Clear();

        foreach (var v in vehicles)
            Vehicles.Add(new VehicleItemViewModel(v));
    }
    
}
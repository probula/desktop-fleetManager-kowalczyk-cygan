using System.Collections.Generic;
using System.Threading.Tasks;
using FleetManager.Models;

namespace FleetManager.Services;

public interface IVehicleService
{
    Task<IEnumerable<Vehicle>> LoadVehicleAsync();
    Task SaveVehicleAsync(IEnumerable<Vehicle> vehicles);
    
}
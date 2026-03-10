using System.Collections.Generic;
using System.Threading.Tasks;
using FleetManager.Models;

namespace FleetManager.Services;

public interface IVehicleService
{
    Task<IEnumerable<Vehicle>> GetVehiclesAsync();
    Task SaveVehicleAsync(IEnumerable<Vehicle> vehicles);
}
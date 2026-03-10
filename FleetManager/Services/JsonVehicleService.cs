using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using FleetManager.Models;

namespace FleetManager.Services;

public class JsonVehicleService : IVehicleService
{
    public readonly string filePath = "vehicles.json";

    public async Task<IEnumerable<Vehicle>> GetVehiclesAsync()
    {
        if (!File.Exists(filePath)) return []; //sprawdz czy istenie lub zwroc puste kolekcje

        using var stream = File.OpenRead(filePath); //using zwalnia plik po skonczeniu uzywania go
        
        return await JsonSerializer.DeserializeAsync<IEnumerable<Vehicle>>(stream) ?? []; //jezli nic nie bedzie to zwroc puste liste
    }

    public async Task SaveVehicleAsync(IEnumerable<Vehicle> vehicles)
    {
        var options = new JsonSerializerOptions { WriteIndented = true };
        using var stream = File.Create(filePath);
        await JsonSerializer.SerializeAsync(stream, vehicles, options);
    }
}
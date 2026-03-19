using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using FleetManager.Models;

namespace FleetManager.Services;

public class JsonVehicleService : IVehicleService
{
    private readonly string filePath = Path.Combine(
        AppDomain.CurrentDomain.BaseDirectory, "Data", "vehicles.json");

    public async Task<IEnumerable<Vehicle>> LoadVehicleAsync()
    {
        if (!File.Exists(filePath))
        {
            Console.WriteLine($"Plik {filePath} nie istnieje!");
            return new List<Vehicle>();
        }

        var json = await File.ReadAllTextAsync(filePath);
        Console.WriteLine($"Zawartość pliku: {json}");

        var vehicles = JsonSerializer.Deserialize<List<Vehicle>>(json);

        return vehicles ?? new List<Vehicle>();
    }

    
    
    public async Task SaveVehicleAsync(IEnumerable<Vehicle> vehicles)
    {
     
        using var stream = File.Create(filePath);

        await JsonSerializer.SerializeAsync(stream, vehicles);
    }
}
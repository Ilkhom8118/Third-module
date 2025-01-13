using CarAccessData.Entity;
using System.Text.Json;

namespace CarRepository.Service;

public class CarRepo : ICarRepo
{
    private List<Carr> cars;
    private readonly string _path;
    private readonly string _directory;
    public CarRepo()
    {
        _path = Path.Combine(Directory.GetCurrentDirectory(), "Data", "Car.json");
        _directory = Path.Combine(Directory.GetCurrentDirectory(), "Data");
        cars = GetAll();
        if (!Directory.Exists(_directory))
        {
            Directory.CreateDirectory(_directory);
        }
        if (!File.Exists(_path))
        {
            File.WriteAllText(_path, "[]");
        }
    }
    private void SaveInformation(List<Carr> obj)
    {
        try
        {
            var json = JsonSerializer.Serialize(obj);
            File.WriteAllText(_path, json);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error saving information: {ex.Message}");
        }
    }
    private List<Carr> GetAll()
    {
        try
        {
            var json = File.ReadAllText(_path);
            var file = JsonSerializer.Deserialize<List<Carr>>(json);
            return file ?? new List<Carr>(); // Agar fayl bo'sh bo'lsa, bo'sh ro'yxat qaytaradi
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error reading file: {ex.Message}");
            return new List<Carr>(); // Xatolik yuz berganda bo'sh ro'yxat qaytariladi
        }
    }
    public Carr AddCar(Carr obj)
    {
        cars.Add(obj);
        SaveInformation(cars);
        return obj;
    }

    public void DeleteCar(Guid id)
    {
        var guId = GetById(id);
        cars.Remove(guId);
        SaveInformation(cars);
    }

    public List<Carr> GetAllCar()
    {
        return GetAll();
    }

    public Carr GetById(Guid id)
    {
        var res = GetAll().FirstOrDefault(c => c.Id == id);
        if (res == null)
        {
            throw new Exception("GetById xatolik bor");
        }
        return res;
    }

    public void UpdateCar(Carr obj)
    {
        var id = GetById(obj.Id);
        cars[cars.IndexOf(id)] = obj;
        SaveInformation(cars);
    }
}

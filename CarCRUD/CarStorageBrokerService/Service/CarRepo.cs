using CarDataAccess.Entity;
using System.Text.Json;

namespace CarStorageBrokerService.Service;

public class CarRepo : ICarRepo
{
    private readonly string _dataPath;
    private readonly string _directoryPath;
    private List<Car> _cars;
    public CarRepo()
    {
        _directoryPath = Path.Combine(Directory.GetCurrentDirectory(), "Data");
        _dataPath = Path.Combine(Directory.GetCurrentDirectory(), "Data", "Car.json");
        if (!Directory.Exists(_directoryPath))
        {
            Directory.CreateDirectory(_directoryPath);
        }
        if (!File.Exists(_dataPath))
        {
            File.WriteAllText(_dataPath, "[]");
        }
        _cars = GetAll();
    }
    private void SaveInformation(List<Car> obj)
    {
        var json = JsonSerializer.Serialize(obj);
        File.WriteAllText(_dataPath, json);
    }
    private List<Car> GetAll()
    {
        var json = File.ReadAllText(_dataPath);
        var file = JsonSerializer.Deserialize<List<Car>>(json);
        if (file == null)
        {
            throw new Exception("Jsondan xatolik bor");
        }
        return file;
    }
    public Car AddCar(Car obj)
    {
        _cars.Add(obj);
        SaveInformation(_cars);
        return obj;
    }

    public void DeleteCar(Guid id)
    {
        var list = GetById(id);
        _cars.Remove(list);
        SaveInformation(_cars);
    }

    public List<Car> GetAllCar()
    {
        return _cars;
    }

    public Car GetById(Guid id)
    {
        var res = GetAll().FirstOrDefault(c => c.Id == id);
        if (res == null)
        {
            throw new Exception("Not find id");
        }
        return res;
    }

    public void UpdateCar(Car obj)
    {
        var id = GetById(obj.Id);
        _cars[_cars.IndexOf(id)] = obj;
        SaveInformation(_cars);
    }
}

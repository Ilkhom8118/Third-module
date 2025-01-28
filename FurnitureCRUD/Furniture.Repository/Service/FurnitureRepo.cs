using Furniture.DataAccess.Entity;
using System.Text.Json;

namespace Furniture.Repository.Service;

public class FurnitureRepo : IFurnitureRepo
{
    private readonly string _path;
    private readonly string _directoryPath;
    private List<Furnitures> sofa;
    public FurnitureRepo()
    {
        _directoryPath = Path.Combine(Directory.GetCurrentDirectory(), "Data");
        _path = Path.Combine(Directory.GetCurrentDirectory(), "Data", "Furniture.json");
        if (!Directory.Exists(_directoryPath))
        {
            Directory.CreateDirectory(_directoryPath);
        }
        if (!Path.Exists(_path))
        {
            File.WriteAllText(_path, "[]");
        }
        sofa = GetAll();
    }
    private void SaveInformation(List<Furnitures> obj)
    {
        var json = JsonSerializer.Serialize(obj);
        File.WriteAllText(_path, json);
    }
    private List<Furnitures> GetAll()
    {
        var json = File.ReadAllText(_path);
        var file = JsonSerializer.Deserialize<List<Furnitures>>(json);
        if (file == null)
        {
            throw new Exception("Jsondan xatolik bor");
        }
        return file;
    }
    public async Task<Furnitures> AddSofaAsync(Furnitures obj)
    {
        sofa.Add(obj);
        SaveInformation(sofa);
        return obj;
    }

    public async Task DeleteSofaAsync(Guid id)
    {
        var guId = await GetByIdAsync(id);
        sofa.Remove(guId);
        SaveInformation(sofa);
    }

    public async Task<Furnitures> GetByIdAsync(Guid id)
    {
        var res = GetAllSofaAsync().Result.FirstOrDefault(s => s.Id == id);
        if (res == null)
        {
            throw new Exception($"Not Find id {id}");
        }
        return res;
    }

    public async Task UpdateSofaAsync(Furnitures obj)
    {
        var id = await GetByIdAsync(obj.Id);
        sofa[sofa.IndexOf(id)] = obj;
        SaveInformation(sofa);
    }

    public async Task<List<Furnitures>> GetAllSofaAsync()
    {
        return GetAll();
    }
}

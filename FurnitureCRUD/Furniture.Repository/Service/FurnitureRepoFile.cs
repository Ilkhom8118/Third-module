using Furniture.DataAccess.Entity;
using System.Text.Json;

namespace Furniture.Repository.Service;

public class FurnitureRepoFile : IFurnitureRepo
{
    private readonly string _path;
    private readonly string _directoryPath;
    private List<Furnitures> sofa;
    public FurnitureRepoFile()
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
        sofa = new List<Furnitures>();
    }
    private async Task SaveInformation(List<Furnitures> obj)
    {
        var json = JsonSerializer.Serialize(obj);
        await File.WriteAllTextAsync(_path, json);
    }
    private async Task<List<Furnitures>> GetAll()
    {
        var json = await File.ReadAllTextAsync(_path);
        var file = JsonSerializer.Deserialize<List<Furnitures>>(json);
        return file;
    }
    public async Task<Furnitures> AddSofaAsync(Furnitures obj)
    {
        sofa.Add(obj);
        await SaveInformation(sofa);
        return obj;
    }

    public async Task DeleteSofaAsync(Guid id)
    {
        var guId = await GetByIdAsync(id);
        sofa.Remove(guId);
        await SaveInformation(sofa);
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
        await SaveInformation(sofa);
    }

    public async Task<List<Furnitures>> GetAllSofaAsync()
    {
        return await GetAll();
    }
}

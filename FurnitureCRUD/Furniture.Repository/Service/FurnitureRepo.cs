using Furniture.DataAccess;
using Furniture.DataAccess.Entity;
using Microsoft.EntityFrameworkCore;

namespace Furniture.Repository.Service;

public class FurnitureRepo : IFurnitureRepo
{
    private readonly MainContext _mainContext;

    public FurnitureRepo(MainContext mainContext)
    {
        _mainContext = mainContext;
    }

    public async Task<Furnitures> AddSofaAsync(Furnitures obj)
    {
        await _mainContext.AddAsync(obj);
        await _mainContext.SaveChangesAsync();
        return obj;
    }

    public async Task DeleteSofaAsync(Guid id)
    {
        var remove = await GetByIdAsync(id);
        _mainContext.Furniture.Remove(remove);
        await _mainContext.SaveChangesAsync();
    }

    public async Task<List<Furnitures>> GetAllSofaAsync()
    {
        var res = await _mainContext.Furniture.ToListAsync();
        return res;

    }

    public async Task<Furnitures> GetByIdAsync(Guid id)
    {
        var sofa = await _mainContext.Furniture.FirstOrDefaultAsync(f => f.Id == id);
        if (sofa == null)
        {
            throw new Exception($"Furniture not found {id}");
        }
        return sofa;
    }

    public async Task UpdateSofaAsync(Furnitures obj)
    {
        throw new Exception("asd");
    }
}

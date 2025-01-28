using Furniture.DataAccess.Entity;

namespace Furniture.Repository.Service;

public interface IFurnitureRepo
{
    Task<Furnitures> AddSofaAsync(Furnitures obj);
    Task DeleteSofaAsync(Guid id);
    Task UpdateSofaAsync(Furnitures obj);
    Task<List<Furnitures>> GetAllSofaAsync();
    Task<Furnitures> GetByIdAsync(Guid id);
}
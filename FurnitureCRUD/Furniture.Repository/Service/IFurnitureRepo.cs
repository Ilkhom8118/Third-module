using Furniture.DataAccess.Entity;

namespace Furniture.Repository.Service;

public interface IFurnitureRepo
{
    Furnitures AddSofa(Furnitures obj);
    void DeleteSofa(Guid id);
    void UpdateSofa(Furnitures obj);
    List<Furnitures> GetAllSofa();
    Furnitures GetById(Guid id);
}
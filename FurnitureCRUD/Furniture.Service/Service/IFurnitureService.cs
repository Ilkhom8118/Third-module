using Furniture.DataAccess.Entity;
using Furniture.Service.Service.DTOs;

namespace Furniture.Service.Service;

public interface IFurnitureService
{
    decimal CalculateTotalWeight();
    void DeleteFurniture(Guid id);
    FurnitureDto GetById(Guid id);
    decimal CalculateTotalValue();
    List<FurnitureDto> GetAllSofa();
    FurnitureDto GetCheapestFurniture();
    void UpdateFurniture(FurnitureDto obj);
    Furnitures AddFurniture(FurnitureDto obj);
    FurnitureDto GetMostExpensiveFurniture();
    List<FurnitureDto> GetAvailableFurnitures();
    List<FurnitureDto> SearchFurnitureByName(string name);
    List<FurnitureDto> GetFurnitureByCategory(string category);
    List<FurnitureDto> GetFurnitureByMaterial(string material);
    List<FurnitureDto> GetFurnitureManufacturedAfterYear(int year);
    List<FurnitureDto> GetFurnituresOrderedByWeight(decimal min, decimal max);
    List<FurnitureDto> GetFurnituresOrderedByPrice(int minPrice, int maxPrice);
}
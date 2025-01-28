using Furniture.DataAccess.Entity;
using Furniture.Service.Service.DTOs;

namespace Furniture.Service.Service;

public interface IFurnitureService
{
    Task<decimal> CalculateTotalWeightAsync();
    Task DeleteFurnitureAsync(Guid id);
    Task<FurnitureDto> GetByIdAsync(Guid id);
    Task<decimal> CalculateTotalValueAsync();
    Task<List<FurnitureDto>> GetAllSofaAsync();
    Task<FurnitureDto> GetCheapestFurnitureAsync();
    Task UpdateFurnitureAsync(FurnitureDto obj);
    Task<Furnitures> AddFurnitureAsync(FurnitureDto obj);
    Task<FurnitureDto> GetMostExpensiveFurnitureAsync();
    Task<List<FurnitureDto>> GetAvailableFurnituresAsync();
    Task<List<FurnitureDto>> SearchFurnitureByNameAsync(string name);
    Task<List<FurnitureDto>> GetFurnitureByCategoryAsync(string category);
    Task<List<FurnitureDto>> GetFurnitureByMaterialAsync(string material);
    Task<List<FurnitureDto>> GetFurnitureManufacturedAfterYearAsync(int year);
    Task<List<FurnitureDto>> GetFurnituresOrderedByWeightAsync(decimal min, decimal max);
    Task<List<FurnitureDto>> GetFurnituresOrderedByPriceAsync(int minPrice, int maxPrice);
}
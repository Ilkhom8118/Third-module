using Furniture.DataAccess.Entity;
using Furniture.Repository.Service;
using Furniture.Service.Service.DTOs;

namespace Furniture.Service.Service;

public class FurnitureService : IFurnitureService
{
    private readonly IFurnitureRepo _sofa;

    public FurnitureService(IFurnitureRepo sofa)
    {
        _sofa = sofa;
    }

    private FurnitureDto ConvertToDto(Furnitures obj)
    {
        return new FurnitureDto()
        {
            Id = obj.Id,
            Name = obj.Name,
            Brand = obj.Brand,
            Color = obj.Color,
            Price = obj.Price,
            Weight = obj.Weight,
            Category = obj.Category,
            Material = obj.Material,
            Dimensions = obj.Dimensions,
            IsAvailable = obj.IsAvailable,
            Description = obj.Description,
            YearManufactured = obj.YearManufactured,
        };
    }

    private Furnitures ConvertToEntity(FurnitureDto obj)
    {
        return new Furnitures()
        {
            Name = obj.Name,
            Brand = obj.Brand,
            Color = obj.Color,
            Price = obj.Price,
            Weight = obj.Weight,
            Category = obj.Category,
            Material = obj.Material,
            Dimensions = obj.Dimensions,
            IsAvailable = obj.IsAvailable,
            Description = obj.Description,
            Id = obj.Id ?? Guid.NewGuid(),
            YearManufactured = obj.YearManufactured,
        };
    }

    public async Task<Furnitures> AddFurnitureAsync(FurnitureDto obj)
    {
        var convert = ConvertToEntity(obj);
        await _sofa.AddSofaAsync(convert);
        return convert;
    }

    public async Task<decimal> CalculateTotalValueAsync()
    {
        var res = await GetAllSofaAsync(); ;
        return res.Sum(f => f.Weight);
    }

    public async Task DeleteFurnitureAsync(Guid id)
    {
        await _sofa.DeleteSofaAsync(id);
    }

    public async Task<List<FurnitureDto>> GetAllSofaAsync()
    {
        var get = await _sofa.GetAllSofaAsync();
        var getDto = get.Select(f => ConvertToDto(f)).ToList();
        return getDto;
    }

    public async Task<List<FurnitureDto>> GetAvailableFurnituresAsync()
    {
        var res = await GetAllSofaAsync();
        return res.Where(f => f.IsAvailable).ToList();
    }

    public async Task<FurnitureDto> GetByIdAsync(Guid id)
    {
        var res = await GetAllSofaAsync();
        var result = res.FirstOrDefault(f => f.Id == id);
        if (result == null)
        {
            throw new Exception($"Not Find id: {id}");
        }
        return result;
    }

    public async Task<FurnitureDto> GetCheapestFurnitureAsync()
    {
        var result = await GetAllSofaAsync();
        var res = result.OrderBy(f => f.Price).FirstOrDefault();
        if (res == null)
        {
            throw new Exception("No Furniture");
        }
        return res;
    }

    public async Task<List<FurnitureDto>> GetFurnitureByCategoryAsync(string category)
    {
        var res = await GetAllSofaAsync();
        return res.Where(f => f.Category == category).ToList();
    }

    public async Task<List<FurnitureDto>> GetFurnitureByMaterialAsync(string material)
    {
        var res = await GetAllSofaAsync();
        return res.Where(f => f.Material == material).ToList();
    }

    public async Task<List<FurnitureDto>> GetFurnitureManufacturedAfterYearAsync(int year)
    {
        var res = await GetAllSofaAsync();
        return res.Where(f => f.YearManufactured == year).ToList();
    }

    public async Task<List<FurnitureDto>> GetFurnituresOrderedByPriceAsync(int minPrice, int maxPrice)
    {
        var res = await GetAllSofaAsync();
        return res.Where(f => f.Price >= minPrice && f.Price <= maxPrice).ToList();
    }

    public async Task<List<FurnitureDto>> GetFurnituresOrderedByWeightAsync(decimal min, decimal max)
    {
        var res = await GetAllSofaAsync();
        return res.Where(f => f.Weight >= min && f.Weight <= max).ToList();
    }

    public async Task<FurnitureDto> GetMostExpensiveFurnitureAsync()
    {
        var result = await GetAllSofaAsync();
        var res = result.OrderByDescending(f => f.Price).FirstOrDefault();
        if (res == null)
        {
            throw new Exception("Qimmat mebellar mavjud emas!");
        }
        return res;
    }

    public async Task<List<FurnitureDto>> SearchFurnitureByNameAsync(string name)
    {
        var res = await GetAllSofaAsync();
        return res.Where(f => f.Name.Contains(name)).ToList();
    }

    public async Task UpdateFurnitureAsync(FurnitureDto obj)
    {
        var convert = ConvertToEntity(obj);
        await _sofa.UpdateSofaAsync(convert);
    }

    public async Task<decimal> CalculateTotalWeightAsync()
    {
        var res = await GetAllSofaAsync();
        return res.Sum(f => f.Weight);
    }
}


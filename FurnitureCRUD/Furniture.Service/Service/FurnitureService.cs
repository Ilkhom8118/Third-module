using Furniture.DataAccess.Entity;
using Furniture.Repository.Service;
using Furniture.Service.Service.DTOs;

namespace Furniture.Service.Service;

public class FurnitureService : IFurnitureService
{
    private readonly IFurnitureRepo sofa;
    public FurnitureService()
    {
        sofa = new FurnitureRepo();
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
            Id = obj.Id ?? Guid.NewGuid(),
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

    public Furnitures AddFurniture(FurnitureDto obj)
    {
        var convert = ConvertToEntity(obj);
        sofa.AddSofa(convert);
        return convert;
    }

    public decimal CalculateTotalValue()
    {
        return GetAllSofa().Sum(f => f.Weight);
    }

    public void DeleteFurniture(Guid id)
    {
        sofa.DeleteSofa(id);
    }

    public List<FurnitureDto> GetAllSofa()
    {
        var get = sofa.GetAllSofa();
        var getDto = get.Select(f => ConvertToDto(f)).ToList();
        return getDto;
    }

    public List<FurnitureDto> GetAvailableFurnitures()
    {
        return GetAllSofa().Where(f => f.IsAvailable).ToList();
    }

    public FurnitureDto GetById(Guid id)
    {
        var res = GetAllSofa().FirstOrDefault(f => f.Id == id);
        if (res == null)
        {
            throw new Exception($"Not Find id: {id}");
        }
        return res;
    }

    public FurnitureDto GetCheapestFurniture()
    {
        var res = GetAllSofa().OrderBy(f => f.Price).FirstOrDefault();
        if (res == null)
        {
            throw new Exception("No Furniture");
        }
        return res;
    }

    public List<FurnitureDto> GetFurnitureByCategory(string category)
    {
        return GetAllSofa().Where(f => f.Category == category).ToList();
    }

    public List<FurnitureDto> GetFurnitureByMaterial(string material)
    {
        return GetAllSofa().Where(f => f.Material == material).ToList();
    }

    public List<FurnitureDto> GetFurnitureManufacturedAfterYear(int year)
    {
        return GetAllSofa().Where(f => f.YearManufactured == year).ToList();
    }

    public List<FurnitureDto> GetFurnituresOrderedByPrice(int minPrice, int maxPrice)
    {
        return GetAllSofa().Where(f => f.Price >= minPrice && f.Price <= maxPrice).ToList();
    }

    public List<FurnitureDto> GetFurnituresOrderedByWeight(decimal min, decimal max)
    {
        return GetAllSofa().Where(f => f.Weight >= min && f.Weight <= max).ToList();
    }

    public FurnitureDto GetMostExpensiveFurniture()
    {
        var res = GetAllSofa().OrderByDescending(f => f.Price).FirstOrDefault();
        if (res == null)
        {
            throw new Exception("Qimmat mebellar mavjud emas!");
        }
        return res;
    }

    public List<FurnitureDto> SearchFurnitureByName(string name)
    {
        return GetAllSofa().Where(f => f.Name.Contains(name)).ToList();
    }

    public void UpdateFurniture(FurnitureDto obj)
    {
        var convert = ConvertToEntity(obj);
        sofa.UpdateSofa(convert);
    }

    public decimal CalculateTotalWeight()
    {
        return GetAllSofa().Sum(f => f.Weight);
    }
}


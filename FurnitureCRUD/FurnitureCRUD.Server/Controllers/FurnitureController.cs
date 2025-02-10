using Furniture.DataAccess.Entity;
using Furniture.Service.Service;
using Furniture.Service.Service.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace FurnitureCRUD.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FurnitureController : ControllerBase
    {
        private readonly IFurnitureService _sofa;

        public FurnitureController(IFurnitureService sofa)
        {
            _sofa = sofa;
        }

        [HttpPost("addFurniture")]

        public async Task<Furnitures> AddFurniture(FurnitureDto obj)
        {
            return await _sofa.AddFurnitureAsync(obj);
        }

        [HttpDelete("deleteFurniture")]
        public async Task DeleteFurniture(Guid id)
        {
            await _sofa.DeleteFurnitureAsync(id);
        }

        [HttpGet("getAllSofa")]

        public async Task<List<FurnitureDto>> GetAllSofa()
        {
            return await _sofa.GetAllSofaAsync();
        }

        [HttpGet("getById")]
        public async Task<FurnitureDto> GetById(Guid id)
        {
            return await _sofa.GetByIdAsync(id);
        }

        [HttpPut("updateFurniture")]
        public async Task UpdateFurniture(FurnitureDto obj)
        {
            await _sofa.UpdateFurnitureAsync(obj);
        }

        [HttpGet("CalculateTotalWeight")]

        public async Task<decimal> CalculateTotalWeight()
        {
            return await _sofa.CalculateTotalWeightAsync();
        }
        [HttpGet("calculateTotalValue")]
        public async Task<decimal> CalculateTotalValue()
        {
            return await _sofa.CalculateTotalValueAsync();
        }

        [HttpGet("getCheapestFurniture")]

        public async Task<FurnitureDto> GetCheapestFurniture()
        {
            return await _sofa.GetCheapestFurnitureAsync();
        }
        [HttpGet("getMostExpensiveFurniture")]
        public async Task<FurnitureDto> GetMostExpensiveFurniture()
        {
            return await _sofa.GetMostExpensiveFurnitureAsync();
        }

        [HttpGet("getAvailableFurnitures")]
        public async Task<List<FurnitureDto>> GetAvailableFurnitures()
        {
            return await _sofa.GetAvailableFurnituresAsync();
        }

        [HttpGet("searchFurnitureByName")]
        public async Task<List<FurnitureDto>> SearchFurnitureByName(string name)
        {
            return await _sofa.SearchFurnitureByNameAsync(name);
        }

        [HttpGet("getFurnitureByCategory")]
        public async Task<List<FurnitureDto>> GetFurnitureByCategory(string category)
        {
            return await _sofa.GetFurnitureByCategoryAsync(category);
        }

        [HttpGet("getFurnitureByMaterial")]
        public async Task<List<FurnitureDto>> GetFurnitureByMaterial(string material)
        {
            return await _sofa.GetFurnitureByMaterialAsync(material);
        }

        [HttpGet("getFurnitureManufacturedAfterYear")]
        public async Task<List<FurnitureDto>> GetFurnitureManufacturedAfterYear(int year)
        {
            return await _sofa.GetFurnitureManufacturedAfterYearAsync(year);
        }
        [HttpGet("getFurnituresOrderedByWeight")]
        public async Task<List<FurnitureDto>> GetFurnituresOrderedByWeight(decimal min, decimal max)
        {
            return await _sofa.GetFurnituresOrderedByWeightAsync(min, max);
        }

        [HttpGet("getFurnituresOrderedByPrice")]
        public async Task<List<FurnitureDto>> GetFurnituresOrderedByPrice(int minPrice, int maxPrice)
        {
            return await _sofa.GetFurnituresOrderedByPriceAsync(minPrice, maxPrice);
        }
    }
}
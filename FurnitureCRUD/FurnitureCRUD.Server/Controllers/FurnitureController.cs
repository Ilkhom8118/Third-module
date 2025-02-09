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
        private readonly IFurnitureService sofa;
        public FurnitureController()
        {
            sofa = new FurnitureService();
        }
        [HttpPost("addFurniture")]

        public async Task<Furnitures> AddFurniture(FurnitureDto obj)
        {
            return await sofa.AddFurnitureAsync(obj);
        }

        [HttpDelete("deleteFurniture")]
        public async Task DeleteFurniture(Guid id)
        {
            await sofa.DeleteFurnitureAsync(id);
        }

        [HttpGet("getAllSofa")]

        public async Task<List<FurnitureDto>> GetAllSofa()
        {
            return await sofa.GetAllSofaAsync();
        }

        [HttpGet("getById")]
        public async Task<FurnitureDto> GetById(Guid id)
        {
            return await sofa.GetByIdAsync(id);
        }

        [HttpPut("updateFurniture")]
        public async Task UpdateFurniture(FurnitureDto obj)
        {
            await sofa.UpdateFurnitureAsync(obj);
        }

        [HttpGet("CalculateTotalWeight")]

        public async Task<decimal> CalculateTotalWeight()
        {
            return await sofa.CalculateTotalWeightAsync();
        }
        [HttpGet("calculateTotalValue")]
        public async Task<decimal> CalculateTotalValue()
        {
            return await sofa.CalculateTotalValueAsync();
        }

        [HttpGet("getCheapestFurniture")]

        public async Task<FurnitureDto> GetCheapestFurniture()
        {
            return await sofa.GetCheapestFurnitureAsync();
        }
        [HttpGet("getMostExpensiveFurniture")]
        public async Task<FurnitureDto> GetMostExpensiveFurniture()
        {
            return await sofa.GetMostExpensiveFurnitureAsync();
        }

        [HttpGet("getAvailableFurnitures")]
        public async Task<List<FurnitureDto>> GetAvailableFurnitures()
        {
            return await sofa.GetAvailableFurnituresAsync();
        }

        [HttpGet("searchFurnitureByName")]
        public async Task<List<FurnitureDto>> SearchFurnitureByName(string name)
        {
            return await sofa.SearchFurnitureByNameAsync(name);
        }

        [HttpGet("getFurnitureByCategory")]
        public async Task<List<FurnitureDto>> GetFurnitureByCategory(string category)
        {
            return await sofa.GetFurnitureByCategoryAsync(category);
        }

        [HttpGet("getFurnitureByMaterial")]
        public async Task<List<FurnitureDto>> GetFurnitureByMaterial(string material)
        {
            return await sofa.GetFurnitureByMaterialAsync(material);
        }

        [HttpGet("getFurnitureManufacturedAfterYear")]
        public async Task<List<FurnitureDto>> GetFurnitureManufacturedAfterYear(int year)
        {
            return await sofa.GetFurnitureManufacturedAfterYearAsync(year);
        }
        [HttpGet("getFurnituresOrderedByWeight")]
        public async Task<List<FurnitureDto>> GetFurnituresOrderedByWeight(decimal min, decimal max)
        {
            return await sofa.GetFurnituresOrderedByWeightAsync(min, max);
        }

        [HttpGet("getFurnituresOrderedByPrice")]
        public async Task<List<FurnitureDto>> GetFurnituresOrderedByPrice(int minPrice, int maxPrice)
        {
            return await sofa.GetFurnituresOrderedByPriceAsync(minPrice, maxPrice);
        }
    }
}
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

        public Furnitures AddFurniture(FurnitureDto obj)
        {
            return sofa.AddFurniture(obj);
        }

        [HttpDelete("deleteFurniture")]
        public void DeleteFurniture(Guid id)
        {
            sofa.DeleteFurniture(id);
        }

        [HttpGet("getAllSofa")]

        public List<FurnitureDto> GetAllSofa()
        {
            return sofa.GetAllSofa();
        }

        [HttpGet("getById")]
        public FurnitureDto GetById(Guid id)
        {
            return sofa.GetById(id);
        }

        [HttpPut("updateFurniture")]
        public void UpdateFurniture(FurnitureDto obj)
        {
            sofa.UpdateFurniture(obj);
        }

        [HttpGet("CalculateTotalWeight")]

        public decimal CalculateTotalWeight()
        {
            return sofa.CalculateTotalWeight();
        }
        [HttpGet("calculateTotalValue")]
        public decimal CalculateTotalValue()
        {
            return sofa.CalculateTotalValue();
        }

        [HttpGet("getCheapestFurniture")]

        public FurnitureDto GetCheapestFurniture()
        {
            return sofa.GetCheapestFurniture();
        }
        [HttpGet("getMostExpensiveFurniture")]
        public FurnitureDto GetMostExpensiveFurniture()
        {
            return sofa.GetMostExpensiveFurniture();
        }

        [HttpGet("getAvailableFurnitures")]
        public List<FurnitureDto> GetAvailableFurnitures()
        {
            return sofa.GetAvailableFurnitures();
        }

        [HttpGet("searchFurnitureByName")]
        public List<FurnitureDto> SearchFurnitureByName(string name)
        {
            return sofa.SearchFurnitureByName(name);
        }

        [HttpGet("getFurnitureByCategory")]
        public List<FurnitureDto> GetFurnitureByCategory(string category)
        {
            return sofa.GetFurnitureByCategory(category);
        }

        [HttpGet("getFurnitureByMaterial")]
        public List<FurnitureDto> GetFurnitureByMaterial(string material)
        {
            return sofa.GetFurnitureByMaterial(material);
        }

        [HttpGet("getFurnitureManufacturedAfterYear")]
        public List<FurnitureDto> GetFurnitureManufacturedAfterYear(int year)
        {
            return sofa.GetFurnitureManufacturedAfterYear(year);
        }
        [HttpGet("getFurnituresOrderedByWeight")]
        public List<FurnitureDto> GetFurnituresOrderedByWeight(decimal min, decimal max)
        {
            return sofa.GetFurnituresOrderedByWeight(min, max);
        }

        [HttpGet("getFurnituresOrderedByPrice")]
        public List<FurnitureDto> GetFurnituresOrderedByPrice(int minPrice, int maxPrice)
        {
            return sofa.GetFurnituresOrderedByPrice(minPrice, maxPrice);
        }
    }
}
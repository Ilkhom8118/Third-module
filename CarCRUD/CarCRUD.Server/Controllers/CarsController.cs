using CarCRUDService.DTOs;
using CarCRUDService.Service;
using CarDataAccess.Entity;
using Microsoft.AspNetCore.Mvc;

namespace CarCRUD.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        private readonly ICarService cars;
        public CarsController()
        {
            cars = new CarService();
        }
        [HttpPost("addCar")]
        public Car AddCarDto(CarDto car)
        {
            return cars.AddCarDto(car);
        }
        [HttpGet("totalPrice")]
        public double TotalPrice()
        {
            return cars.TotalPrice();
        }
        [HttpGet("getAllCars")]
        public List<CarDto> GetAllCars()
        {
            return cars.GetAllCars();
        }
        [HttpGet("getMostExpensiveCar")]
        public CarDto GetMostExpensiveCar()
        {
            return cars.GetMostExpensiveCar();
        }
        [HttpGet("getLowestMileAgeCar")]
        public CarDto GetLowestMileAgeCar()
        {
            return GetLowestMileAgeCar();
        }
        [HttpPut("updateCarDto")]
        public void UpdateCarDto(CarDto car)
        {
            cars.UpdateCarDto(car);
        }
        [HttpDelete("deleteCarDto")]
        public void DeleteCarDto(Guid carId)
        {
            cars.DeleteCarDto(carId);
        }
        [HttpGet("getCarByIdDto")]
        public CarDto GetCarByIdDto(Guid carId)
        {
            return cars.GetCarByIdDto(carId);
        }
        [HttpGet("getCarsSortedByPrice")]
        public List<CarDto> GetCarsSortedByPrice()
        {
            return cars.GetCarsSortedByPrice();
        }
        [HttpGet("getRecentCars")]
        public List<CarDto> GetRecentCars(int years)
        {
            return cars.GetRecentCars(years);
        }
        [HttpGet("getAllCarByBrand")]
        public List<CarDto> GetAllCarByBrand(string brand)
        {
            return cars.GetAllCarByBrand(brand);
        }
        [HttpGet("searchCarsByModel")]
        public List<CarDto> SearchCarsByModel(string keyword)
        {
            return cars.SearchCarsByModel(keyword);
        }
        [HttpGet("getAverageCapasityByBrand")]
        public double GetAverageCapasityByBrand(string brand)
        {
            return cars.GetAverageCapasityByBrand(brand);
        }
        [HttpGet("getCarsByYearRange")]
        public List<CarDto> GetCarsByYearRange(int startYear, int endYear)
        {
            return cars.GetCarsByYearRange(startYear, endYear);
        }
        [HttpGet("searchCarsWithinPriceRange")]
        public List<CarDto> SearchCarsWithinPriceRange(double minPrice, double maxPrice)
        {
            return cars.SearchCarsWithinPriceRange(minPrice, maxPrice);
        }
    }
}

using CarAccessData.Entity;
using CarService.Sevice;
using CarService.Sevice.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace Car.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {
        private readonly ICarService cars;
        public CarController()
        {
            cars = new CarServicee();
        }
        [HttpGet("fasTest")]
        public CarBaseDto FasTest()
        {
            return cars.FasTest();
        }
        [HttpPut("updateCar")]
        public void UpdateCar(Carr obj)
        {
            cars.UpdateCar(obj);
        }
        [HttpDelete("deleteCar")]
        public void DeleteCar(Guid id)
        {
            cars.DeleteCar(id);
        }
        [HttpGet("slowestCar")]
        public CarBaseDto SlowestCar()
        {
            return cars.SlowestCar();
        }
        [HttpPost("AddCar")]
        public Carr AddCar(CarBaseDto obj)
        {
            return cars.AddCar(obj);
        }
        [HttpGet("getById")]
        public CarBaseDto GetById(Guid id)
        {
            return cars.GetById(id);
        }
        [HttpGet("getAllCars")]
        public List<CarBaseDto> GetAllCars()
        {
            return cars.GetAllCars();
        }
        [HttpGet("getMostExpensiveCar")]
        public CarBaseDto GetMostExpensiveCar()
        {
            return cars.GetMostExpensiveCar();
        }
        [HttpGet("getTKmInTime")]
        public double GetTKmInTime(double minut, string model)
        {
            return cars.GetTKmInTime(minut, model);
        }
        [HttpGet("getCarAfterYear")]
        public List<CarBaseDto> GetCarAfterYear(int year)
        {
            return cars.GetCarAfterYear(year);
        }
        [HttpGet("getCarBeforeYear")]
        public List<CarBaseDto> GetCarBeforeYear(int year)
        {
            return GetCarBeforeYear(year);
        }
        [HttpGet("getTimeOfKm")]
        public double GetTimeOfKm(double km, string model)
        {
            return cars.GetTimeOfKm(km, model);
        }
        [HttpGet("mostExpensiveCar")]
        public List<CarBaseDto> MostExpensiveCar(int minPrace, int maxPrice)
        {
            return cars.MostExpensiveCar(minPrace, maxPrice);
        }
        [HttpGet("getTypesOfCarsWithTheSameModel")]
        public List<CarBaseDto> GetTypesOfCarsWithTheSameModel(string brand)
        {
            return cars.GetTypesOfCarsWithTheSameModel(brand);
        }
    }
}

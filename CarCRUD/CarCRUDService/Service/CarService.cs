using CarCRUDService.DTOs;
using CarDataAccess.Entity;
using CarStorageBrokerService.Service;

namespace CarCRUDService.Service;

public class CarService : ICarService
{
    private readonly ICarRepo cars;
    public CarService()
    {
        cars = new CarRepo();
    }
    private Car ConvertToEntity(CarDto obj)
    {
        return new Car()
        {
            Year = obj.Year,
            Brand = obj.Brand,
            Color = obj.Color,
            Model = obj.Model,
            Price = obj.Price,
            MileAge = obj.MileAge,
            Id = obj.Id ?? Guid.NewGuid(),
            EngineCapasity = obj.EngineCapasity,
        };
    }
    private CarDto ConvertToDto(Car obj)
    {
        return new CarDto()
        {
            Id = obj.Id,
            Year = obj.Year,
            Brand = obj.Brand,
            Color = obj.Color,
            Model = obj.Model,
            Price = obj.Price,
            MileAge = obj.MileAge,
            EngineCapasity = obj.EngineCapasity,
        };
    }
    public Car AddCarDto(CarDto car)
    {
        var convert = ConvertToEntity(car);
        return cars.AddCar(convert);
    }

    public void DeleteCarDto(Guid carId)
    {
        cars.DeleteCar(carId);
    }

    public List<CarDto> GetAllCarByBrand(string brand)
    {
        return GetAllCars().Where(c => c.Brand == brand).ToList();
    }

    public List<CarDto> GetAllCars()
    {
        return cars.GetAllCar().Select(c => ConvertToDto(c)).ToList();
    }

    public double GetAverageCapasityByBrand(string brand)
    {
        return GetAllCars().Where(c => c.Brand == brand).Average(c => c.EngineCapasity);
    }

    public CarDto GetCarByIdDto(Guid carId)
    {
        var res = GetAllCars().FirstOrDefault(c => c.Id == carId);
        if (res == null)
        {
            throw new Exception("Not Find id");
        }
        return res;
    }

    public List<CarDto> GetCarsByYearRange(int startYear, int endYear)
    {
        return GetAllCars().Where(c => c.Year >= startYear && c.Year <= endYear).ToList();
    }

    public List<CarDto> GetCarsSortedByPrice()
    {
        return GetAllCars().OrderBy(c => c.Price).ToList();
    }

    public CarDto GetLowestMileAgeCar()
    {
        var res = GetAllCars().OrderBy(c => c.MileAge).FirstOrDefault();
        if (res == null)
        {
            throw new Exception("Null GetLowestMileAgeCar");
        }
        return res;
    }

    public CarDto GetMostExpensiveCar()
    {
        var res = GetAllCars().OrderByDescending(c => c.Price).FirstOrDefault();
        if (res == null)
        {
            throw new Exception("Null GetLowestMileAgeCar");
        }
        return res;
    }

    public List<CarDto> GetRecentCars(int years)
    {
        return GetAllCars().Where(c => c.Year == years).ToList();
    }

    public List<CarDto> SearchCarsByModel(string keyword)
    {
        return GetAllCars().Where(c => c.Model.Contains(keyword)).ToList();
    }

    public List<CarDto> SearchCarsWithinPriceRange(double minPrice, double maxPrice)
    {
        return GetAllCars().Where(c => c.Price > minPrice && c.Price < maxPrice).ToList();
    }

    public double TotalPrice()
    {
        return GetAllCars().Sum(c => c.Price);
    }

    public void UpdateCarDto(CarDto car)
    {
        cars.UpdateCar(ConvertToEntity(car));
    }
}

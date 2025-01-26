using CarCRUDService.DTOs;
using CarDataAccess.Entity;

namespace CarCRUDService.Service;

public interface ICarService
{
    double TotalPrice();
    Car AddCarDto(CarDto car);
    List<CarDto> GetAllCars();
    CarDto GetMostExpensiveCar();
    CarDto GetLowestMileAgeCar();
    void UpdateCarDto(CarDto car);
    void DeleteCarDto(Guid id);
    CarDto GetCarByIdDto(Guid carId);
    List<CarDto> GetCarsSortedByPrice();
    List<CarDto> GetRecentCars(int years);
    List<CarDto> GetAllCarByBrand(string brand);
    List<CarDto> SearchCarsByModel(string keyword);
    double GetAverageCapasityByBrand(string brand);
    List<CarDto> GetCarsByYearRange(int startYear, int endYear);
    List<CarDto> SearchCarsWithinPriceRange(double minPrice, double maxPrice);
}
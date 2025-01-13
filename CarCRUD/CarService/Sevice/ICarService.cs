using CarAccessData.Entity;
using CarService.Sevice.DTOs;

namespace CarService.Sevice;

public interface ICarService
{
    CarBaseDto FasTest();
    void UpdateCar(Carr obj);
    void DeleteCar(Guid id);
    CarBaseDto SlowestCar();
    Carr AddCar(CarBaseDto obj);
    CarBaseDto GetById(Guid id);
    List<CarBaseDto> GetAllCars();
    CarBaseDto GetMostExpensiveCar();
    List<CarBaseDto> GetCarAfterYear(int year);
    List<CarBaseDto> GetCarBeforeYear(int year);
    double GetTimeOfKm(double km, string model);
    double GetTKmInTime(double minut, string model);
    List<CarBaseDto> MostExpensiveCar(int minPrace, int maxPrice);
    List<CarBaseDto> GetTypesOfCarsWithTheSameModel(string brand);
}
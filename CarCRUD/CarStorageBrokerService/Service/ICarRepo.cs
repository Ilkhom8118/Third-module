using CarDataAccess.Entity;

namespace CarStorageBrokerService.Service;

public interface ICarRepo
{
    Car AddCar(Car obj);
    void DeleteCar(Guid id);
    void UpdateCar(Car obj);
    List<Car> GetAllCar();
    Car GetById(Guid id);
}
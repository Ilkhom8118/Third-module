using CarAccessData.Entity;

namespace CarRepository.Service;

public interface ICarRepo
{
    Carr AddCar(Carr obj);
    void DeleteCar(Guid id);
    void UpdateCar(Carr obj);
    List<Carr> GetAllCar();
    Carr GetById(Guid id);
}
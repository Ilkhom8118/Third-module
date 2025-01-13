using CarAccessData.Entity;
using CarRepository.Service;
using CarService.Sevice.DTOs;

namespace CarService.Sevice
{

    public class CarServicee : ICarService
    {
        private readonly ICarRepo cars;
        public CarServicee()
        {
            cars = new CarRepo();
        }

        private Carr ConvertToEntity(CarBaseDto obj)
        {
            return new Carr()
            {
                Brend = obj.Brend,
                Color = obj.Color,
                Model = obj.Model,
                Price = obj.Price,
                FuelType = obj.FuelType,
                Description = obj.Description,
                Id = obj.Id ?? Guid.NewGuid(),
                MaximumSpeed = obj.MaximumSpeed,
                YearManufactured = obj.YearManufactured,
            };
        }
        private CarBaseDto ConvertToDto(Carr obj)
        {
            return new CarBaseDto()
            {
                Id = obj.Id,
                Brend = obj.Brend,
                Color = obj.Color,
                Model = obj.Model,
                Price = obj.Price,
                FuelType = obj.FuelType,
                Description = obj.Description,
                MaximumSpeed = obj.MaximumSpeed,
                YearManufactured = obj.YearManufactured,
            };
        }
        public Carr AddCar(CarBaseDto obj)
        {
            var convert = ConvertToEntity(obj);
            cars.AddCar(convert);
            return convert;
        }

        public void DeleteCar(Guid id)
        {
            cars.DeleteCar(id);
        }

        public CarBaseDto FasTest()
        {
            var res = GetAllCars().OrderByDescending(m => m.MaximumSpeed).FirstOrDefault();
            if (res == null)
            {
                throw new Exception("Tez yuradigan moshina yo'q");
            }
            return res;
        }

        public List<CarBaseDto> GetAllCars()
        {
            return cars.GetAllCar().Select(c => ConvertToDto(c)).ToList();
        }

        public CarBaseDto GetById(Guid id)
        {
            var res = GetAllCars().FirstOrDefault(m => m.Id == id);
            if (res == null)
            {
                throw new Exception("Bunday id topilmadi?");
            }
            return res;
        }

        public List<CarBaseDto> GetCarAfterYear(int year)
        {
            return GetAllCars().Where(c => c.YearManufactured > year).ToList();
        }

        public List<CarBaseDto> GetCarBeforeYear(int year)
        {
            return GetAllCars().Where(c => c.YearManufactured < year).ToList();
        }

        public CarBaseDto GetMostExpensiveCar()
        {
            var res = GetAllCars().FirstOrDefault(c => c.Price == GetAllCars().Max(cr => cr.Price));
            if (res == null)
            {
                throw new Exception("Eng qimmat Moshina Error");
            }
            return res;
        }

        public double GetTimeOfKm(double km, string model)
        {
            return km / GetAllCars().FirstOrDefault(c => c.Model == model).MaximumSpeed;

        }

        public double GetTKmInTime(double minut, string model)
        {
            return GetAllCars().FirstOrDefault(c => c.Model == model).MaximumSpeed * minut;
        }

        public List<CarBaseDto> GetTypesOfCarsWithTheSameModel(string brand)
        {
            return GetAllCars().Where(c => c.Brend == brand).ToList();
        }

        public List<CarBaseDto> MostExpensiveCar(int minPrace, int maxPrice)
        {
            return GetAllCars().Where(c => c.Price >= minPrace && c.Price <= maxPrice).ToList();
        }

        public CarBaseDto SlowestCar()
        {
            var res = GetAllCars().OrderBy(c => c.MaximumSpeed).FirstOrDefault();
            if (res == null)
            {
                throw new Exception("Eng sekin yuradigan moshina yo'q");
            }
            return res;
        }

        public void UpdateCar(Carr obj)
        {
            cars.UpdateCar(obj);
        }
    }
}

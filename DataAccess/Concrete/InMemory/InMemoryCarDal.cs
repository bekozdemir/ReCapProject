using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;
        public InMemoryCarDal()
        {
            _cars = new List<Car>
            {
                new Car{Id=1, BrandId=1, ColorId=1, DailyPrice=50000, Description="SUV", ModelYear=2020},
                new Car{Id=2, BrandId=1, ColorId=2, DailyPrice=80000, Description="SEDAN", ModelYear=2021},
                new Car{Id=3, BrandId=2, ColorId=3, DailyPrice=30000, Description="SEDAN", ModelYear=2018},
                new Car{Id=4, BrandId=3, ColorId=4, DailyPrice=70000, Description="COUPE", ModelYear=2019},
                new Car{Id=5, BrandId=3, ColorId=7, DailyPrice=70000, Description="COUPE", ModelYear=2013},
            };
        }
        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            Car carToDelete = _cars.SingleOrDefault(c=>c.Id == car.Id);

            _cars.Remove(carToDelete);

        }

        public List<Car> GetAll() 
        {
            return _cars;
        }

        public List<Car> GetById(int Id)
        {
            return _cars.Where(c=> c.Id==Id).ToList();
        }

        public void Update(Car car)
        {
            Car carToUpdate = _cars.SingleOrDefault(c=>c.Id == car.Id);
            carToUpdate.Id = car.Id;
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.Description = car.Description;
            carToUpdate.ModelYear = car.ModelYear;

        }
    }
}

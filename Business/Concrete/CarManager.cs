using Business.Abstract;
using DataAccess.Abstract;
using DataAccess.Concrete;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        public List<Car> GetAll()
        {
            return _carDal.GetAll();
        }

        public void Update(Car car)
        {
             _carDal.Update(car);
        }

        public void Delete(Car car)
        {
            _carDal.Delete(car);
        }

        public void Add(Car car)
        {
            _carDal.Add(car);
        }

        public List<Car> GetById(int Id)
        {
            return _carDal.GetById(Id);
        }

    }
}

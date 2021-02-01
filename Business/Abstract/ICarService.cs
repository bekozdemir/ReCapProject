using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICarService
    {
        List<Car> GetAll();
        void Update(Car car);
        void Delete(Car car);
        void Add(Car car);
        List<Car> GetById(int Id);

    }
}

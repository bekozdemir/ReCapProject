using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Abstract
{
    public interface ICarDal: IEntityRepository<Car>
    {
        List<CarDetailDto> GetCarDetailsByCarId(int carId);
        List<CarDetailDto> GetCarsDetail(Expression<Func<Car, bool>> filter = null);

    }
}

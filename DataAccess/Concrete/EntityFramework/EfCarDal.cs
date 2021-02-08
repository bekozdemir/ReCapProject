using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, CarsCompanyContext>, ICarDal
    {
        public List<CarDetailDto> GetCarDetails()
        {
            using (CarsCompanyContext context = new CarsCompanyContext())
            {
                var result = from c in context.Cars
                             join b in context.Brands
                             on c.BrandId equals b.BrandId 
                             join co in context.Colors
                             on c.ColorId equals co.ColorId
                             select new CarDetailDto {BrandName=b.BrandName, CarName=c.CarName, 
                                 ColorName=co.ColorName, DailyPrice=c.DailyPrice };
                return result.ToList();
                             

                            
            }
        }
    }
}

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
        public List<CarDetailDto> GetCarDetailsByCarId(int carId)
        {
            using (CarsCompanyContext context = new CarsCompanyContext())
            {
                var result = from c in context.Cars.Where(c => c.Id == carId)
                             join b in context.Brands on c.BrandId equals b.BrandId
                             join co in context.Colors on c.ColorId equals co.ColorId
                             select new CarDetailDto {
                                 Id = c.Id,
                                 Description = c.Description,
                                 ModelYear = c.ModelYear,
                                 BrandName = b.BrandName,
                                 CarName = c.CarName,
                                 ColorName = co.ColorName,
                                 DailyPrice = c.DailyPrice,
                                 RentStatus = !context.Rentals.Any(r => r.CarId == carId && r.ReturnDate == null),
                                 FindeksScore = c.FindeksScore
                             };
                return result.ToList();                          
            }
        }

        public List<CarDetailDto> GetCarsDetail(Expression<Func<Car, bool>> filter = null)
        {
            using (CarsCompanyContext context = new CarsCompanyContext())
            {
                var result = from c in  filter == null? context.Cars : context.Cars.Where(filter)
                             join b in context.Brands on c.BrandId equals b.BrandId
                             join co in context.Colors on c.ColorId equals co.ColorId
                             select new CarDetailDto
                             {
                                 Id = c.Id,
                                 Description = c.Description,
                                 ModelYear = c.ModelYear,
                                 BrandName = b.BrandName,
                                 CarName = c.CarName,
                                 ColorName = co.ColorName,
                                 DailyPrice = c.DailyPrice,
                                 FindeksScore = c.FindeksScore
                             };
                return result.ToList();
            }
        }
    }
}

using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental, CarsCompanyContext>, IRentalDal
    {
        public List<RentCarDetailDto> GetRentDetails(Expression<Func<Rental, bool>> filter = null)
        {
            using (CarsCompanyContext context = new CarsCompanyContext())
            {
                var result = from r in filter is null? context.Rentals : context.Rentals.Where(filter)  
                             join c in context.Cars on r.CarId equals c.Id
                             join cu in context.Customers on r.CustomerId equals cu.Id
                             join u in context.Users on cu.UserId equals u.Id
                             select new RentCarDetailDto
                             {
                                 CarName=c.CarName,
                                 CompanyName=cu.CompanyName,
                                 CustomerName=u.FirstName+u.LastName,
                                 RentDate=r.RentDate,
                                 ReturnDate=r.ReturnDate,
                             };
                return result.ToList();
            }
        }
    }
}

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
    public class EfCustomerDal : EfEntityRepositoryBase<Customer, CarsCompanyContext>, ICustomerDal
    {
        public List<CustomerDetailDto> GetCustomerDetailDto()
        {
            using (CarsCompanyContext context = new CarsCompanyContext())
            {
                var result = from cu in context.Customers
                             join u in context.Users on cu.UserId equals u.Id
                             select new CustomerDetailDto
                             {
                                 CustomerId = cu.Id,
                                 CompanyName = cu.CompanyName,
                                 FirstName = u.FirstName,
                                 LastName = u.LastName
                             };
                return result.ToList();
            }
        }
    }
}

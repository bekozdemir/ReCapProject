using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarImageDal : EfEntityRepositoryBase<CarImage, CarsCompanyContext>, ICarImageDal
    {
        public bool IsExist(int id)
        {
            using (CarsCompanyContext context = new CarsCompanyContext())
            {
                return context.CarImages.Any(p => p.Id == id);
            }
        }
    }
}

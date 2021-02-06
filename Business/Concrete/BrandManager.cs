using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class BrandManager : IBrandService
    {
        IBrandDal _brandDal;

        public BrandManager(IBrandDal brandDal)
        {
            _brandDal = brandDal;
        }

        public List<Brand> GetAll()
        {
            return _brandDal.GetAll();
        }

        public void Update(Brand brand)
        {
            if (brand.BrandName.Length > 2)
            {
                 _brandDal.Update(brand);
                 Console.WriteLine("Brand name has updated!");
            }
            else
            {
                 Console.WriteLine("Invalid entry!");
            }
        }

        public void Delete(Brand brand)
        {
            _brandDal.Delete(brand);
        }

         public void Add(Brand brand)
         {
             if (brand.BrandName.Length > 2)
             {
                _brandDal.Add(brand);
                Console.WriteLine("Car has added!");
             }
             else
             {
                Console.WriteLine("Invalid entry!");
             }

         }

        public Brand GetByBrandId(int brandId)
        {
            return _brandDal.Get(c => c.BrandId == brandId);
        }

           
    }
}

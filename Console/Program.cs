using Business.Concrete;
using DataAccess.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new EfCarDal());
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            ColorManager colorManager = new ColorManager(new EfColorDal());


            foreach (var car in carManager.GetCarsByBrandId(3))
            {
                Console.WriteLine("{0}\t{1}\t{2}", 
                car.Id, brandManager.GetByBrandId(car.BrandId).BrandName, colorManager.GetByColorId(car.ColorId).ColorName);
            }

            Console.WriteLine("--------------------------\n");

            foreach (var car in carManager.GetCarsByColorId(1))
            {
                Console.WriteLine("{0}\t{1}\t{2}",
                car.Id, brandManager.GetByBrandId(car.BrandId).BrandName, colorManager.GetByColorId(car.ColorId).ColorName);
            }

            Console.WriteLine("--------------------------\n");

            carManager.Add(new Car {ColorId=2, BrandId=2, DailyPrice=1000000, Description="SPORT", ModelYear=2021});
     

            carManager.Add(new Car { Id = 9, ColorId = 2, BrandId = 2, DailyPrice = -20000, Description = "SPORT", ModelYear = 2021 });

            brandManager.Add(new Brand {BrandId=4, BrandName="x" });
        }
    }
}

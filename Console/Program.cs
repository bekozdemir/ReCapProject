using Business.Concrete;
using DataAccess.Concrete;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new InMemoryCarDal());

            Car updateCar = new Car { Id = 1, BrandId = 5, ColorId = 8, DailyPrice = 100000, Description = "SPORT", ModelYear = 2021 };
            Car deleteCar = new Car { Id = 4 };
            Car addCar = new Car { Id = 6, BrandId = 5, ColorId = 0, DailyPrice = 20000, Description = "COUPE", ModelYear = 2012 };
        
            Console.WriteLine("---------------FIRST LIST-----------------");

            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine(car.Id +", "+ car.BrandId +", "+ car.ColorId + ", " + car.Description+ ", "+ car.ModelYear+ ", "+ car.DailyPrice);
            }
            carManager.Update(updateCar);

            carManager.Add(addCar);

            carManager.Delete(deleteCar);

        
            Console.WriteLine("\n---------------NEW LIST-----------------");

            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine(car.Id + ", " + car.BrandId + ", " + car.ColorId + ", " + car.Description + ", " + car.ModelYear + ", " + car.DailyPrice);
            }


            Console.WriteLine("\n---------------GETBYID---------------");

            foreach (var car in carManager.GetById(3))
            {
                Console.WriteLine(car.Id + ", " + car.BrandId + ", " + car.ColorId + ", " + car.Description + ", " + car.ModelYear + ", " + car.DailyPrice);
            }
            
        }
    }
}

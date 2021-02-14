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
            //BrandTest();
            //CarDetailsTest();
            //GetCarsByBrandIdTest();
            //ColorGetByIdTest();
            //BrandAddTest();
            //BrandDeleteTest();
            //UpdateTest();
            //UserAddTest();
            //RentAddedTest();
            //RentUpdateTest();
            //RentList();
            //RentDetailsTest();
            //AddRentTest();
        }

        private static void AddRentTest()
        {
            RentalManager rentalManager = new RentalManager(new EfRentalDal());
            var result = rentalManager.Add(new Rental { CarId = 3, CustomerId = 7, RentDate = new DateTime(2021, 2, 20) });
            Console.WriteLine(result.Message);
        }

        private static void RentDetailsTest()
        {
            RentalManager rentalManager = new RentalManager(new EfRentalDal());
            var result = rentalManager.GetRentDetails();
            if (result.Success == true)
            {
                foreach (var rent in result.Data)
                {
                    Console.WriteLine("CustomerName:{0} - CarName:{1} - CompanyName:{2} - RentDate:{3} - ReturnDate:{4}",
                        rent.CustomerName, rent.CarName, rent.CompanyName, rent.RentDate, rent.ReturnDate);
                }
                Console.WriteLine(result.Message);
            }
            else
            {
                Console.WriteLine(result.Message);
            }
        }

        private static void RentList()
        {
            RentalManager rentalManager = new RentalManager(new EfRentalDal());
            var result = rentalManager.GetAll();
            if (result.Success)
            {
                foreach (var rent in result.Data)
                {
                    Console.WriteLine("CarId: {0} -  CustomerId: {1} - Id: {2} - RentDate: {3} - ReturnDate: {4}",
                        rent.CarId, rent.CustomerId, rent.Id, rent.RentDate, rent.ReturnDate);
                }
                Console.WriteLine(result.Message);
            }
            else
            {
                Console.WriteLine(result.Message);
            }
        }

        private static void RentUpdateTest()
        {
            RentalManager rentalManager = new RentalManager(new EfRentalDal());
            var result = rentalManager.Update(new Rental
            {
                Id = 13,
                CarId = 3,
                CustomerId = 4,
                RentDate = new DateTime(2021, 02, 14),
                ReturnDate = null,
            });
            Console.WriteLine(result.Message);
        }

        private static void RentAddTest()
        {
            RentalManager rentalManager = new RentalManager(new EfRentalDal());
            var result = rentalManager.Add(new Rental
            {
                CustomerId = 8,
                CarId = 7,
                RentDate = new DateTime(2021, 02, 13), 
            });
            Console.WriteLine(result.Message);
        }

        private static void UserAddTest()
        {
            UserManager userManager = new UserManager(new EfUserDal());
            var result = userManager.Add(new User { FirstName = "Berkay", LastName = "Özdemir", Email = "xxxxxxxx", Password = "********" });
            Console.WriteLine(result.Message);
        }

        private static void UpdateTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            carManager.Update(new Car { BrandId = 1, CarName = "Jetta", ColorId = 1, DailyPrice = 300000, Description = "SEDAN", Id = 1, ModelYear = 2021 });
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            brandManager.Update(new Brand { BrandName = "Volkswagen", BrandId = 1 });
        }

        private static void BrandDeleteTest()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            brandManager.Delete(new Brand { BrandName = "Ferrari2", BrandId = 7 });
        }

        private static void BrandAddTest()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            brandManager.Add(new Brand { BrandName = "Ferrari2" });
        }

        private static void ColorGetByIdTest()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());
            var search_color = colorManager.GetById(3).Data;
            Console.WriteLine(search_color.ColorName);
        }

        private static void GetCarsByBrandIdTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            foreach (var car in carManager.GetCarsByBrandId(4).Data)
            {
                Console.WriteLine(car.CarName);
            }
        }

        private static void CarDetailsTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            var result = carManager.GetCarDetails();
            if (result.Success==true)
            {
                foreach (var car in result.Data)
                {
                Console.WriteLine("{0} / {1} / {2} / {3}", car.CarName, car.BrandName, car.ColorName, car.DailyPrice);
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }
            
        }

        private static void BrandTest()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            foreach (var brand in brandManager.GetAll().Data)
            {
                Console.WriteLine(brand.BrandName);
            }
        }
    }
}

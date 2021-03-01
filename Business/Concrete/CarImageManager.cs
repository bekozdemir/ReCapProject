using Business.Abstract;
using Business.Constants;
using Core.Utilities.BusinessRules;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageService
    {
        ICarImageDal _carImageDal;
        IFileProcess _fileProcess;
        ICarService _carService;
        public CarImageManager(ICarImageDal carImageDal, IFileProcess fileProcess, ICarService carService)
        {
            _carImageDal = carImageDal;
            _fileProcess = fileProcess;
            _carService = carService;
        }
        public IResult Add(int id, IFormFile file)
        {
            IResult result = BusinessRules.Run(CheckIfImageLimitExceed(id));

            if (result != null)
            {
                return null;
            }

            string fileName = Guid.NewGuid().ToString();
            CarImage carImg = new CarImage
            {
                CarId = id,
                Date = DateTime.UtcNow,
                ImagePath = fileName
            };
            _carImageDal.Add(carImg);
            var fileResult = _fileProcess.Upload(fileName, file);
            return new SuccessResult();
        }

        public IResult Delete(int id)
        {
            IResult result = BusinessRules.Run(CheckIfImageLimitExceed(id));
            if (result != null)
            {
                return null;
            }
            CarImage listedCar = GetById(id).Data;
            _carImageDal.Delete(listedCar);
            if (listedCar.ImagePath != "default.png")
            {
                _fileProcess.Delete(listedCar.ImagePath);
            }
            return new SuccessResult();

        }

        public IDataResult<CarImage> GetByCarId(int carId)
        {
            var result = _carImageDal.Get(img => img.CarId == carId);
            return new SuccessDataResult<CarImage>(result.ImagePath);
        }

        public IDataResult<CarImage> GetById(int id)
        {
            var result = _carImageDal.Get(img=>img.Id == id);
            return new SuccessDataResult<CarImage>(result.ImagePath);
        }

        public IResult Update(int id, IFormFile file)
        {
            IResult result = BusinessRules.Run(CheckIfImageLimitExceed(id));

            if (result != null)
            {
                return null;
            }

            string fileName = Guid.NewGuid().ToString();
            CarImage carImg = new CarImage
            {
                CarId = id,
                Date = DateTime.UtcNow,
                ImagePath = fileName
            };
            _carImageDal.Update(carImg);
            var fileResult = _fileProcess.Upload(fileName, file);
            return new SuccessResult(result.Message);
        }

        private IResult CheckIfImageLimitExceed(int id)
        {
            var result = _carImageDal.GetAll(img=>img.Id==id);
            if (result.Count>5)
            {
                return new ErrorResult(Messages.ImageLimitExceeded);
            }
            return new SuccessResult();
        }

        private IResult CheckIfCarImageExists()
        {
            var result = _carImageDal.GetAll(img => img.ImagePath == null).Any();
            if (result)
            {
                return new ErrorResult(Messages.ImageDoesntExists);
            }
            return new SuccessResult();
        }

        
    }
}

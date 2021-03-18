using Business.Abstract;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Helpers;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using Business.Constants;

using Core.Utilities.BusinessRules;
using Core.Constants;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageService
    {
        private readonly ICarImageDal _carImageDal;

        public CarImageManager(ICarImageDal carImageDal)
        {
            _carImageDal = carImageDal;
        }

        [ValidationAspect(typeof(CarImagesOperationDtoValidator))]
        public IResult Add(CarImagesOperationDto carImagesOperationDto)
        {
            var result = BusinessRules.Run(CheckCarImageCount(carImagesOperationDto.CarId));
            if (result != null)
            {
                return result;
            }

            foreach (var file in carImagesOperationDto.Images)
            {
                _carImageDal.Add(new CarImage
                {
                    CarId = carImagesOperationDto.CarId,
                    ImagePath = FileProcessHelper.Upload(DefaultNameOrPath.ImageDirectory, file).Data
            });
            }

            return new SuccessResult(Messages.AddCarImageMessage);
        }

        public IResult Delete(CarImage entity)
        {
            var imageData = _carImageDal.Get(p => p.Id == entity.Id);
            FileProcessHelper.Delete(imageData.ImagePath);
            _carImageDal.Delete(imageData);
            return new SuccessResult(Messages.DeleteCarImageMessage);
        }

        public IDataResult<CarImage> Get(int id)
        {
            return new SuccessDataResult<CarImage>(_carImageDal.Get(p => p.Id == id));
        }

        public IDataResult<List<CarImage>> GetAll()
        {
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll());
        }

        [ValidationAspect(typeof(CarImagesOperationDtoValidator))]
        public IResult Update(CarImagesOperationDto carImagesOperationDto)
        {
            foreach (var file in carImagesOperationDto.Images)
            {
                var result = BusinessRules.Run(
                    CheckIfCarImagesId(carImagesOperationDto.Id),
                    CheckCarImageCount(carImagesOperationDto.CarId)
                );
                if (result != null)
                {
                    return result;
                }

                FileProcessHelper.Delete(_carImageDal.Get(p => p.Id == carImagesOperationDto.Id).ImagePath);
                _carImageDal.Update(new CarImage
                {
                    Id = carImagesOperationDto.Id,
                    CarId = carImagesOperationDto.CarId,
                    ImagePath = FileProcessHelper.Upload(DefaultNameOrPath.ImageDirectory, file).Data
                });
            }

            return new SuccessResult(Messages.EditCarImageMessage);
        }

        public IDataResult<List<CarImage>> GetAllByCarId(int carId)
        {


            var getAllbyCarIdResult = _carImageDal.GetAll(p => p.CarId == carId);
            if (getAllbyCarIdResult.Count == 0)
            {
                return new SuccessDataResult<List<CarImage>>(new List<CarImage>
                {
                    new CarImage
                    {
                        Id = -1,
                        CarId = carId,
                        Date = DateTime.MinValue,
                        ImagePath = DefaultNameOrPath.NoImagePath
                    }
                });
            }

            return new SuccessDataResult<List<CarImage>>(getAllbyCarIdResult);
        }

        #region Car Image Business Rules

        private IResult CheckCarImageCount(int carId)
        {
            if (_carImageDal.GetAll(p => p.CarId == carId).Count > 4)
            {
                return new ErrorResult(Messages.AboveImageAddingLimit);
            }

            return new SuccessResult();
        }

        private IResult CheckIfCarImagesId(int Id)
        {
            if (_carImageDal.Get(p => p.Id == Id) == null)
            {
                return new ErrorResult(Messages.CarImageNotFound);
            }

            return new SuccessResult();
        }

        #endregion Car Image Business Rules
    }
}

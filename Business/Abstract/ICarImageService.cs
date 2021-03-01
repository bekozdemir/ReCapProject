using Core.Utilities.Results;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICarImageService
    {
        IDataResult<CarImage> GetById(int Id);
        IDataResult<CarImage> GetByCarId(int carId);
        IResult Update(int id, IFormFile file);
        IResult Delete(int id);
        IResult Add(int id, IFormFile file);
    }
}

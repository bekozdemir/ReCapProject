using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {
        IRentalDal _rentalDal;
        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }
        public IResult Add(Rental rental)
        {
            var available = _rentalDal.GetRentDetails(r=>r.CarId == rental.CarId && r.ReturnDate==null);
            if (available.Count > 0)
            {
                Console.WriteLine("The car you choose has already rented, please choose another one!");
                return new ErrorResult(Messages.InvalidEntry);
            }
            else
            {
                _rentalDal.Add(rental);
                return new SuccessResult(Messages.SuccessfullOperation);
            }
            
        }

        public IResult Delete(Rental rental)
        {
            _rentalDal.Delete(rental);
            return new SuccessResult(Messages.SuccessfullOperation);
        }

        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll(), Messages.SuccessfullOperation);
        }

        public IDataResult<Rental> GetById(int rentalId)
        {
            return new SuccessDataResult<Rental>(_rentalDal.Get(r => r.Id == rentalId), Messages.SuccessfullOperation);
        }

        public IDataResult<List<RentCarDetailDto>> GetRentDetails(Expression<Func<Rental, bool>> filter = null)
        {
            return new SuccessDataResult<List<RentCarDetailDto>>(_rentalDal.GetRentDetails(),Messages.SuccessfullOperation);
        }

        public IResult Update(Rental rental)
        {
            _rentalDal.Update(rental);
            return new SuccessResult(Messages.SuccessfullOperation);
        }
    }
}

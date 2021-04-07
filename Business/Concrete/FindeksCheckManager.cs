using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class FindeksCheckManager : IFindeksCheckService
    {
        ICarService _carService;
        ICustomerService _customerService;

        public FindeksCheckManager(ICarService carService, ICustomerService customerService)
        {
            _carService = carService;
            _customerService = customerService;
        }
        public IResult FindeksChecker(int carId, int customerId)
        {
            int carFindeks = _carService.GetById(carId).Data.FindeksScore;
            int customerFindeks = _customerService.GetById(customerId).Data.Findeks;
            if (carFindeks > customerFindeks )
            {
                return new ErrorResult(Messages.FindeksError);
            }
            else
            {
                return new SuccessResult(Messages.FindeksSuccess);
            }
        }
    }
}

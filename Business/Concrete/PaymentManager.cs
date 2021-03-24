using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class PaymentManager : IPaymentService
    {
        
        public IDataResult<List<RentalPaymentDto>> ReceivePayment(Payment payment, Rental rental)
        {
            var minPayment = 100;
            if (payment.Amount < minPayment)
            {
                return new ErrorDataResult<List<RentalPaymentDto>>(Messages.BalanceErrorMessage);
            }
            return new SuccessDataResult<List<RentalPaymentDto>>(Messages.SuccessfullOperation);
        }
    }
}

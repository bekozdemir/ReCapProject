using Business.Abstract;
using Core.Aspects.Autofac.Transaction;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RentalsController : ControllerBase
    {
        IRentalService _rentalService;
        IPaymentService _paymentService;

        public RentalsController(IRentalService rentalService, IPaymentService paymentService)
        {
            _rentalService = rentalService;
            _paymentService = paymentService;
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _rentalService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getrentdetails")]
        public IActionResult GetRentDetails()
        {
            Thread.Sleep(1000);

            var result = _rentalService.GetRentDetails();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _rentalService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("add")]
        public IActionResult Add(Rental rental)
        {
            var result = _rentalService.Add(rental);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete(Rental rental)
        {
            var result = _rentalService.Delete(rental);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("update")]
        public IActionResult Update(Rental rental)
        {
            var result = _rentalService.Update(rental);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("paymentadd")]
        [TransactionScopeAspect]
        public ActionResult PaymentAdd(RentalPaymentDto rentalPaymentDto)
        {
            var paymentResult = _paymentService.ReceivePayment(rentalPaymentDto.Payment, rentalPaymentDto.Rental);
            if (!paymentResult.Success)
            {
                return BadRequest(paymentResult);
            }
            var result = _rentalService.Add(rentalPaymentDto.Rental);

            if (result.Success)
            {
                return Ok(result);                
            }
            return BadRequest(result); 
        }
    }
}

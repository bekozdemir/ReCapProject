using Business.Abstract;
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
    public class FindeksCheckController : ControllerBase
    {
        IFindeksCheckService _findeksCheckService;

        public FindeksCheckController(IFindeksCheckService findeksCheckService)
        {
            _findeksCheckService = findeksCheckService;
        }

        [HttpGet("findekschecker")]
        public IActionResult FindeksChecker(int carId, int customerId)
        {
            Thread.Sleep(2000);
            var result = _findeksCheckService.FindeksChecker(carId, customerId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}

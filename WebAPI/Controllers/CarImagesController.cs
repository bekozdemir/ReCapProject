using Business.Abstract;
using Entities.Concrete;
using Entities.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarImagesController : ControllerBase
    {
        private readonly ICarImageService _carImageService;

        public CarImagesController(ICarImageService carImageService)
        {
            _carImageService = carImageService;
        }

        [HttpPost("add")]
        [DisableRequestSizeLimit]
        public IActionResult Add([FromForm] CarImagesOperationDto carImagesOperationDto)
        {
            var result = _carImageService.Add(carImagesOperationDto);
            if (result.Success)
                return Ok(result);
            return BadRequest(result);
        }

        [HttpPost("update")]
        [DisableRequestSizeLimit]
        public IActionResult Update([FromForm] CarImagesOperationDto carImagesOperationDto)
        {
            var result = _carImageService.Update(carImagesOperationDto);
            if (result.Success)
                return Ok(result);
            return BadRequest(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete(CarImage carImage)
        {
            return Ok(_carImageService.Delete(carImage));
        }

        [HttpGet("get")]
        public IActionResult Get()
        {
            return Ok(_carImageService.GetAll());
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            return Ok(_carImageService.GetAll());
        }

        [HttpGet("getallbycarid")]
        public IActionResult GetAllByCarId(int carId)
        {
            return Ok(_carImageService.GetAllByCarId(carId));
        }
    }
}
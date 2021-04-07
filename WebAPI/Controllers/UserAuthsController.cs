using Business.Abstract;
using Core.Entities.Concrete;
using Entities.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserAuthsController : ControllerBase
    {
        IUserAuthService _userAuthService;
        IAuthService _authService;
        public UserAuthsController(IUserAuthService userAuthService, IAuthService authService)
        {
            _userAuthService = userAuthService;
            _authService = authService;
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int userAuthId)
        {
            var result = _userAuthService.GetById(userAuthId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("update")]
        public IActionResult Update(UserForRegisterDto userForRegisterDto)
        {
            var userExists = _authService.UserIdExists(userForRegisterDto.Id);
            if (!userExists.Success)
            {
                return BadRequest(userExists.Message);
            }
            var registerResult= _authService.Register(userForRegisterDto, userForRegisterDto.Password);
            var result = _authService.CreateAccessToken(registerResult.Data);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }


        //[HttpGet("getbyemail")]
        //public IActionResult GetByEmail(string email)
        //{
        //    var result = _userAuthService.GetByMail(email);
        //    if (result.)
        //    {
        //        return Ok(result);
        //    }
        //    return BadRequest(result);
        //}

        [HttpGet("getclaim")]
        public IActionResult GetClaim(UserAuth userAuth)
        {
            var result = _userAuthService.GetClaims(userAuth);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


        [HttpPost("add")]
        public IActionResult Add(UserAuth userAuth)
        {
            var result = _userAuthService.Add(userAuth);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

    }
}

using Business.Abstract;
using Business.Constants;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using Core.Utilities.Security.Hashing;
using Core.Utilities.Security.JWT;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class AuthManager : IAuthService
    {
        private IUserAuthService _userAuthService;
        private ITokenHelper _tokenHelper;

        public AuthManager(IUserAuthService userAuthService, ITokenHelper tokenHelper)
        {
            _userAuthService = userAuthService;
            _tokenHelper = tokenHelper;
        }

        public IDataResult<UserAuth> Register(UserForRegisterDto userForRegisterDto, string password)
        {
            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(password, out passwordHash, out passwordSalt);
            var userAuth = new UserAuth
            {
                Email = userForRegisterDto.Email,
                FirstName = userForRegisterDto.FirstName,
                LastName = userForRegisterDto.LastName,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                Status = true
            };
            _userAuthService.Add(userAuth);
            return new SuccessDataResult<UserAuth>(userAuth, Messages.UserRegistered);
        }

        public IDataResult<UserAuth> Login(UserForLoginDto userForLoginDto)
        {
            var userToCheck = _userAuthService.GetByMail(userForLoginDto.Email);
            if (userToCheck == null)
            {
                return new ErrorDataResult<UserAuth>(Messages.UserNotFound);
            }

            if (!HashingHelper.VerifyPasswordHash(userForLoginDto.Password, userToCheck.PasswordHash, userToCheck.PasswordSalt))
            {
                return new ErrorDataResult<UserAuth>(Messages.PasswordError);
            }

            return new SuccessDataResult<UserAuth>(userToCheck, Messages.SuccessfullLogin);
        }

        public IResult UserExists(string email)
        {
            if (_userAuthService.GetByMail(email) != null)
            {
                return new ErrorResult(Messages.UserAlreadyExists);
            }
            return new SuccessResult();
        }

        public IDataResult<AccessToken> CreateAccessToken(UserAuth userAuth)
        {
            var claims = _userAuthService.GetClaims(userAuth);
            var accessToken = _tokenHelper.CreateToken(userAuth, claims.Data);
            return new SuccessDataResult<AccessToken>(accessToken, Messages.AccessTokenCreated);
        }

        public IResult UserIdExists(int id)
        {
            var userAuth = _userAuthService.GetById(id);
            if (userAuth != null)
            {
                return new SuccessResult("Kullanıcı mevcut");
            }
            return new ErrorResult("Kullanıcı bulunamadı.");
        }  
    }
}

using Business.Abstract;
using Business.Constants;
using Core.Entities.Concrete;
using Core.Utilities.BusinessRules;
using Core.Utilities.Results;
using Core.Utilities.Security.Hashing;
using DataAccess.Abstract;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class UserAuthManager : IUserAuthService
    {
        IUserAuthDal _userAuthDal;

        public UserAuthManager(IUserAuthDal userAuthDal)
        {
            _userAuthDal = userAuthDal;
        }

        public IDataResult<List<OperationClaim>> GetClaims(UserAuth userAuth)
        {
            return new SuccessDataResult<List<OperationClaim>> (_userAuthDal.GetClaims(userAuth),Messages.SuccessfullOperation);
        }

        public IResult Add(UserAuth userAuth)
        {
            _userAuthDal.Add(userAuth);
            return new SuccessResult(Messages.SuccessfullOperation);
        }

        public UserAuth GetByMail(string email)
        {
            return _userAuthDal.Get(u => u.Email == email);
        }

        public IDataResult<UserAuth> GetById(int userAuthId)
        {
            return new SuccessDataResult<UserAuth>(_userAuthDal.Get(u => u.Id == userAuthId), Messages.SuccessfullOperation);

        }
        

        public IDataResult<UserAuth> Update(UserForRegisterDto userForRegisterDto, string password)
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
                Status = true,
            };
            _userAuthDal.Update(userAuth);
            return new SuccessDataResult<UserAuth>(userAuth, Messages.UserAuthUpdated);
        }


        
    }
}

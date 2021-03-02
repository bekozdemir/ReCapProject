using Business.Abstract;
using Core.Entities.Concrete;
using DataAccess.Abstract;
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

        public List<OperationClaim> GetClaims(UserAuth userAuth)
        {
            return _userAuthDal.GetClaims(userAuth);
        }

        public void Add(UserAuth userAuth)
        {
            _userAuthDal.Add(userAuth);
        }

        public UserAuth GetByMail(string email)
        {
            return _userAuthDal.Get(u => u.Email == email);
        }
    }
}

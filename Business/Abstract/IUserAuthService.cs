using Core.Entities.Concrete;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IUserAuthService
    {
        List<OperationClaim> GetClaims(UserAuth userAuth);
        void Add(UserAuth userAuth);
        UserAuth GetByMail(string email);
    }
}

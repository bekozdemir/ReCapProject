using Core.Entities.Concrete;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IUserAuthService
    {
        
        IResult Add(UserAuth userAuth);
        UserAuth GetByMail(string email);
        IDataResult<List<OperationClaim>> GetClaims(UserAuth userAuth);
        IDataResult<UserAuth> GetById(int userAuthId);
        IDataResult<UserAuth> Update(UserForRegisterDto userForRegisterDto, string password);
        
    }
}

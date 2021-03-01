using Core.Utilities.Results;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IFileProcess
    {
        Task<IResult> Upload(string fileName, IFormFile fileList);
        IResult Delete(string path);
    }
}

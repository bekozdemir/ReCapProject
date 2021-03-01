using Business.Abstract;
using Core.Utilities.Results;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class FileManager: IFileProcess
    {
        private readonly IHostingEnvironment _environment;
        string FileDirectory;

        public FileManager(IHostingEnvironment environment)
        {
            _environment = environment;
            FileDirectory = environment.ContentRootPath + "/Images/";
        }
        
        public async Task<IResult> Upload(string fileName, IFormFile file)
        {
            using (var fileStream = new FileStream(Path.Combine(FileDirectory, fileName.ToString() + ".png"), FileMode.Create, FileAccess.Write))
            {
                await file.CopyToAsync(fileStream);
            }
            return new SuccessResult();
        }
        
        public IResult Delete(string path)
        {
            var roadpath = Path.Combine(FileDirectory, path + ".png");
            if (File.Exists(roadpath))
            {
                File.Delete(roadpath);
            }
            return new SuccessResult();
        }
    }
}

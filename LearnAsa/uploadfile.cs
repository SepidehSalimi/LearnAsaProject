using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace LearnAsa
{
    public class uploadfile
    {
        private readonly IWebHostEnvironment _webhostenviroment;
        public uploadfile(IWebHostEnvironment webHostEnvironment)
        {
            _webhostenviroment = webHostEnvironment;
        }
        public string upload(IFormFile file)
        {
            if (file == null) return "";
            var path = _webhostenviroment.WebRootPath + "\\images\\teacher\\" + file.FileName;
            using var f = System.IO.File.Create(path);
            file.CopyTo(f);
            return file.FileName;
        } 
  
        public string uploadVideo(IFormFile file)
        {
            if (file == null) return "";
            var path = _webhostenviroment.WebRootPath + "\\videos\\course\\" + file.FileName;
            using var f = System.IO.File.Create(path);
            file.CopyTo(f);
            path = path.Split("wwwroot")[1];
            return path;
        }
    }
}

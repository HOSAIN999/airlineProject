using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;
namespace AirlineTicket
{
    public class UpLoadfile
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        public UpLoadfile(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }
        public string UpLoad(IFormFile file)
        {
            if (file == null) return "";
            var path = _webHostEnvironment.WebRootPath + "\\image\\Ticket\\" + file.FileName;
            using var f = System.IO.File.Create(path);
            file.CopyTo(f);
            return file.FileName;
        }
    }
}

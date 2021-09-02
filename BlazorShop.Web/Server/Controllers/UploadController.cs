using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorShop.Web.Server.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UploadController : ControllerBase
    {
        private readonly IWebHostEnvironment environment;
        public string imagepath;
        public UploadController(IWebHostEnvironment environment)
        {
            this.environment = environment;
        }


        [HttpPost]
        public async Task Post()
        {
            if (HttpContext.Request.Form.Files.Any())
            {
                foreach (var file in HttpContext.Request.Form.Files)
                {
                    string filename = Path.GetFileName(file.FileName);
                    //var path = Path.Combine(environment.ContentRootPath, "uploads", file.FileName);
                    //var path = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\uploads\", file.FileName+@"\");
                    var path = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\uploads\Categories\");
                    path = path.Replace("\\Server", "\\Client");
                    if(!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }
                    imagepath = path;
                    using (var stream = new FileStream(path+filename ,FileMode.OpenOrCreate))
                    {
                        await file.CopyToAsync(stream);
                    }
                    //using (var stream = new FileStream(path, FileMode.Create))
                    //{
                    //    await file.CopyToAsync(stream);
                    //}
                }
            }
        }

        
    }
}
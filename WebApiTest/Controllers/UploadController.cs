using Microsoft.AspNetCore.Mvc;

namespace WebApiTest.Controllers
{
    [Route("api/upload")]
    [ApiController]
    public class UploadController : ControllerBase
    {
        private readonly IWebHostEnvironment _environment;

        public UploadController(IWebHostEnvironment environment)
        {
            _environment = environment;
        }

        [HttpPost("images")]
        public async Task<IActionResult> UploadImages(List<IFormFile> images)
        {
            var webpPath = Path.Combine(_environment.WebRootPath, "webp");

            if (!Directory.Exists(webpPath))
            {
                Directory.CreateDirectory(webpPath);
            }

            foreach(var image in images)
            {
                var extension = Path.GetExtension(image.FileName);
                Console.WriteLine(extension);

                var filePath = Path.Combine(webpPath, image.FileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await image.CopyToAsync(stream);
                }
            }

            return Ok(new { Message = "Imagen cargada exitosamente" });
        }
    }
}

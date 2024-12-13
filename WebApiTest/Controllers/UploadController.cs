using Microsoft.AspNetCore.Mvc;

namespace WebApiTest.Controllers
{
    [Route("api/images")]
    [ApiController]
    public class UploadController : ControllerBase
    {
        private readonly IWebHostEnvironment _environment;

        public UploadController(IWebHostEnvironment environment)
        {
            _environment = environment;
        }

        [HttpPost]
        public async Task<IActionResult> UploadImages(List<IFormFile> images)
        {
            var webpPath = Path.Combine(_environment.WebRootPath, "webp");

            if (!Directory.Exists(webpPath))
            {
                Directory.CreateDirectory(webpPath);
            }

            foreach(var image in images)
            {
                // Leer los primeros bytes para validar la firma
                using var stream = image.OpenReadStream();
                byte[] header = new byte[12];
                await stream.ReadAsync(header, 0, header.Length);

                // Validar la firma WebP (RIFF....WEBP)
                string signature = System.Text.Encoding.ASCII.GetString(header, 0, 4); // "RIFF"
                string format = System.Text.Encoding.ASCII.GetString(header, 8, 4);   // "WEBP"

                if (signature != "RIFF" || format != "WEBP")
                {
                    return BadRequest(new { Message = "El archivo no es una imagen WebP válida." });
                }

                var filePath = Path.Combine(webpPath, image.FileName);

                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await image.CopyToAsync(fileStream);
                }
            }

            return Ok(new { Message = "Imagen cargada exitosamente" });
        }
    }
}

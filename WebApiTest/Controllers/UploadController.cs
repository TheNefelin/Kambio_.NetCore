using ClassLibraryModels.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebApiTest.Controllers
{
    [Route("api/images")]
    [ApiController]
    public class UploadController : ControllerBase
    {
        private readonly ILogger<UploadController> _logger;
        private readonly IWebHostEnvironment _environment;
        private readonly ImageProcess _imageProcess;

        public UploadController(
            ILogger<UploadController> logger,
            IWebHostEnvironment environment, 
            ImageProcess imageProcess)
        {
            _logger = logger;
            _environment = environment;
            _imageProcess = imageProcess;
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
                using var stream = image.OpenReadStream();

                _logger.LogWarning("Validate if image is WebP");
                bool isValidWebP = _imageProcess.IsWebp(stream);

                if (!isValidWebP)
                {
                    _logger.LogError("WebP image is not valid");
                    return BadRequest(new { Message = $"{image.FileName} no es una imagen WebP válida." });
                }

                var filePath = Path.Combine(webpPath, image.FileName);

                _logger.LogInformation("Save validate WebP image");
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await image.CopyToAsync(fileStream);
                }
            }

            return Ok(new { Message = "Imagen cargada exitosamente" });
        }

        [HttpPost("to_webp")]
        public async Task<IActionResult> ToWebP(List<IFormFile> images)
        {
            var webpPath = Path.Combine(_environment.WebRootPath, "webp");
            if (!Directory.Exists(webpPath))
                Directory.CreateDirectory(webpPath);

            var errors = new List<string>();

            foreach (var image in images)
            {
                using var stream = image.OpenReadStream();

                if (!_imageProcess.IsJpeg(stream) && !_imageProcess.IsPng(stream)) {
                    errors.Add($"El archivo {image.FileName} no es válido.");
                }
                else
                {
                    try
                    {
                        stream.Position = 0;
                        _imageProcess.ConvertAndSaveToWebP(stream, webpPath, image.FileName);
                    }
                    catch (Exception ex)
                    {
                        errors.Add(ex.Message);
                    }
                }
            }

            if (errors.Count > 0) 
            {
                return StatusCode(207, new { Message = "Algunas imágenes fallaron al procesarse.", Errors = errors });
            }

            return Ok(new { Message = "Imagen cargada exitosamente" });
        }
    }
}

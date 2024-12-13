using ClassLibraryModels.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace WebApiTest.Controllers
{
    [Route("api/product")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ILogger<ProductController> _logger;

        public ProductController(ILogger<ProductController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<ProductDTO>> GetAll(CancellationToken cancellationToken) {
            int prueba = 123456;
            _logger.LogInformation("HttpGet {Time} - {@prueba}", DateTime.Now, prueba);

            return Ok();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAll(int id, CancellationToken cancellationToken)
        {
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> Insert(CancellationToken cancellationToken)
        {
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Update(int id, CancellationToken cancellationToken)
        {
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id, CancellationToken cancellationToken)
        {
            return Ok();
        }
    }
}

using ClassLibraryModels.DTOs;
using ClassLibraryModels.DTOs.Auth;
using ClassLibraryServer.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WebApiTest.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IAuthService _authService;

        public AuthController(IConfiguration configuration, IAuthService authService)
        {
            _configuration = configuration;
            _authService = authService;
        }

        [HttpPost("login-google")]
        public async Task<ActionResult<ResponseApiDTO<TokenDTO>>> LoginGoogle(RequestLoginDTO login, CancellationToken cancellationToken)
        {
            return Unauthorized();
        }

        [HttpPost("login-apple")]
        public async Task<IActionResult> LoginApple(RequestLoginDTO login, CancellationToken cancellationToken)
        {
            return Unauthorized();
        }

        [HttpPost("login-email")]
        public async Task<IActionResult> LoginEmail(RequestLoginDTO login, CancellationToken cancellationToken)
        {
            var jwtConfig = new JwtConfigDTO
            {
                Key = _configuration["JWT:Key"]!,
                Issuer = _configuration["JWT:Issuer"]!,
                Audience = _configuration["JWT:Audience"]!,
                ExpireMin = int.Parse(_configuration["JWT:ExpireMin"]!),
            };

            var response = await _authService.LoginAsync(login, jwtConfig, cancellationToken);
            return StatusCode(response.StatusCode, response);
        }

        [HttpPost("logout")]
        public async Task<ActionResult<ResponseApiDTO<object>>> Loginout(RequestLoginDTO login, CancellationToken cancellationToken)
        {
            return Unauthorized();
        }
    }
}

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ParkingApp.API.Services;
using Swashbuckle.AspNetCore.Annotations;

namespace ParkingApp.API.Controllers
{
    [ApiController] // 🔴 REQUIRED
    [Route("api/auth")]
    [ApiExplorerSettings(GroupName = "v1")] // optional but recommended
    public class AuthController : ControllerBase
    {
        private readonly JwtTokenService _jwtService;

        public AuthController(JwtTokenService jwtService)
        {
            _jwtService = jwtService;
        }

        [HttpPost("login")]
        [AllowAnonymous]
        [SwaggerOperation(
            Summary = "Login",
            Description = "Authenticate user and return JWT token",
            Tags = new[] { "Auth" }
        )]
        public IActionResult Login([FromBody] LoginRequest request)
        {
            if (request.Email != "admin@parking.com" || request.Password != "123456")
                return Unauthorized("Invalid credentials");

            var token = _jwtService.GenerateToken("1", request.Email);

            return Ok(new
            {
                access_token = token,
                TokenType= "Bearer"
            });
        }
    }

    public class LoginRequest
    {
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
    }
}

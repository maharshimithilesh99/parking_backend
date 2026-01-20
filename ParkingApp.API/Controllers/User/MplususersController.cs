using Microsoft.AspNetCore.Mvc;
using ParkingApp.API.Helpers;
using ParkingApp.Businesslogic.IRepositories;
using ParkingApp.Businesslogic.Repositories;
using ParkingApp.Businesslogic.Services;
using ParkingApp.Infrastructure.DTO.Master;
using ParkingApp.Infrastructure.DTO.User;
using System.Security.Claims;

namespace ParkingApp.API.Controllers.User
{
    [Route("api/[controller]")]
    [ApiController]
    public class MplususersController : ControllerBase
    {
        private IMplususersBusinessLogicProvider _IMplususersBusinessLogicProvider;
        private readonly JwtTokenService _jwtService;
        public MplususersController(IMplususersBusinessLogicProvider mplususersBusinessLogicProvider, JwtTokenService jwtService)
        {
            _IMplususersBusinessLogicProvider = mplususersBusinessLogicProvider;
            _jwtService = jwtService;
        }
        [HttpPost("create")]
        public async Task<IActionResult> CreateUser([FromBody] MplususersDto mplususersDto)
        {
            var result = await _IMplususersBusinessLogicProvider.CreateUserAsync(mplususersDto);
            if (!result.Success)
                return BadRequest(new ApiResponse<string>(null, false, result.Message));

            return Ok(new ApiResponse<MplususersDto>(result.Data, true, result.Message));
        }
        [HttpPost("token")]
        public async Task<IActionResult> UserLogin(UserLogin Login)
        {
            var result = await _IMplususersBusinessLogicProvider.UserLoginAsync(Login);
            if (!result.Success)
                return BadRequest(new ApiResponse<string>(null, false, result.Message));

            return Ok(new ApiResponse<LoginResponseDto>(result.Data, true, result.Message));
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(long id)
        {
            #region VerifyToken
            var authHeader = Request.Headers["Authorization"].ToString();
            if (!authHeader.StartsWith("Bearer "))
                return BadRequest(new ApiResponse<string>(null, false, "Token missing"));
            var token = authHeader.Replace("Bearer ", "");
            var principal = _jwtService.VerifyToken(token);
            if (principal == null)
                return BadRequest(new ApiResponse<string>(null, false, "Invalid or expired token"));
            var userIdClaim = principal.FindFirstValue(ClaimTypes.NameIdentifier);
            if (!int.TryParse(userIdClaim, out var userId))
            {
                return BadRequest(new ApiResponse<string>(null, false, "Invalid user id in token"));
            }
            var RoleIdClaim = principal.FindFirstValue(ClaimTypes.Role);
            if (!int.TryParse(RoleIdClaim, out var roleId))
            {
                return BadRequest(new ApiResponse<string>(null, false, "Invalid role id in token"));
            }
            string? UserName = principal.FindFirstValue(ClaimTypes.Name);
            #endregion
            var result = await _IMplususersBusinessLogicProvider.GetUserByIdAsync(id);
            return result.Success ? Ok(result) : NotFound(result);
        }
        [HttpGet("list")]
        public async Task<IActionResult> GetUser()
        {
            #region VerifyToken
            var authHeader = Request.Headers["Authorization"].ToString();
            if (!authHeader.StartsWith("Bearer "))
                return BadRequest(new ApiResponse<string>(null, false, "Token missing"));
            var token = authHeader.Replace("Bearer ", "");
            var principal = _jwtService.VerifyToken(token);
            if (principal == null)
                return BadRequest(new ApiResponse<string>(null, false, "Invalid or expired token"));
            var userIdClaim = principal.FindFirstValue(ClaimTypes.NameIdentifier);
            if (!int.TryParse(userIdClaim, out var userId))
            {
                return BadRequest(new ApiResponse<string>(null, false, "Invalid user id in token"));
            }
            var RoleIdClaim = principal.FindFirstValue(ClaimTypes.Role);
            if (!int.TryParse(RoleIdClaim, out var roleId))
            {
                return BadRequest(new ApiResponse<string>(null, false, "Invalid role id in token"));
            }
            string? UserName = principal.FindFirstValue(ClaimTypes.Name);
            #endregion
            var result = await _IMplususersBusinessLogicProvider.GetUsersAsync();
            return Ok(result);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(long id)
        {
            #region VerifyToken
            var authHeader = Request.Headers["Authorization"].ToString();
            if (!authHeader.StartsWith("Bearer "))
                return BadRequest(new ApiResponse<string>(null, false, "Token missing"));
            var token = authHeader.Replace("Bearer ", "");
            var principal = _jwtService.VerifyToken(token);
            if (principal == null)
                return BadRequest(new ApiResponse<string>(null, false, "Invalid or expired token"));
            var userIdClaim = principal.FindFirstValue(ClaimTypes.NameIdentifier);
            if (!int.TryParse(userIdClaim, out var userId))
            {
                return BadRequest(new ApiResponse<string>(null, false, "Invalid user id in token"));
            }
            var RoleIdClaim = principal.FindFirstValue(ClaimTypes.Role);
            if (!int.TryParse(RoleIdClaim, out var roleId))
            {
                return BadRequest(new ApiResponse<string>(null, false, "Invalid role id in token"));
            }
            string? UserName = principal.FindFirstValue(ClaimTypes.Name);
            #endregion
            var result = await _IMplususersBusinessLogicProvider.DeleteUserAsync(id);
            return result.Success ? Ok(result) : NotFound(result);
        }
    }
}

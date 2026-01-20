using Microsoft.AspNetCore.Mvc;
using ParkingApp.API.Helpers;
using ParkingApp.Businesslogic.IRepositories;
using ParkingApp.Businesslogic.Repositories;
using ParkingApp.Businesslogic.Services;
using ParkingApp.Infrastructure.DTO.Master;
using ParkingApp.Infrastructure.DTO.User;
using System.Security.Claims;

namespace ParkingApp.API.Controllers.Master
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenumasterController : ControllerBase
    {
        private IMenumasterBusinessLogicProvider _IMenumasterBusinessLogicProvider;
        private readonly JwtTokenService _jwtService;
        public MenumasterController(IMenumasterBusinessLogicProvider menumasterBusinessLogicProvider, JwtTokenService jwtService)
        {
            _IMenumasterBusinessLogicProvider = menumasterBusinessLogicProvider;
            _jwtService = jwtService;
        }
        [HttpPost("create")]
        public async Task<IActionResult> CreateRole([FromBody] MenumasterDto menumasterDto)
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
            menumasterDto.Createdby = userId;
            var result = await _IMenumasterBusinessLogicProvider.CreateMenuAsync(menumasterDto);
            if (!result.Success)
                return BadRequest(new ApiResponse<string>(null, false, result.Message));

            return Ok(new ApiResponse<MenumasterDto>(result.Data, true, result.Message));
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetMenuById(long id)
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
            var result = await _IMenumasterBusinessLogicProvider.GetMenuByIdAsync(id);
            return result.Success ? Ok(result) : NotFound(result);
        }
        [HttpPut("update")]
        public async Task<IActionResult> UpdateMenu([FromBody] MenumasterDto menumasterDto)
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
            //menumasterDto.Modifyby = userId;
            var result = await _IMenumasterBusinessLogicProvider.UpdateMenuAsync(menumasterDto);
            return result.Success ? Ok(result) : BadRequest(result);
        }
        [HttpGet("list")]
        public async Task<IActionResult> GetMenus()
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
            var result = await _IMenumasterBusinessLogicProvider.GetMenusAsync();
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMenu(long id)
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
            var result = await _IMenumasterBusinessLogicProvider.DeleteMenuAsync(id);
            return result.Success ? Ok(result) : NotFound(result);
        }
    }
}

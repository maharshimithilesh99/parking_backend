using Microsoft.AspNetCore.Mvc;
using ParkingApp.API.Helpers;
using ParkingApp.Businesslogic.IRepositories;
using ParkingApp.Businesslogic.Repositories;
using ParkingApp.Businesslogic.Services;
using ParkingApp.Infrastructure.DTO.Master;
using ParkingApp.Infrastructure.DTO.User;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace ParkingApp.API.Controllers.User
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolemasterController : ControllerBase
    {
        private IRolemasterBusinessLogicProvider _IRolemasterBusinessLogicProvider;
        private readonly JwtTokenService _jwtService;
        public RolemasterController(IRolemasterBusinessLogicProvider rolemasterBusinessLogicProvider, JwtTokenService jwtService)
        {
            _IRolemasterBusinessLogicProvider = rolemasterBusinessLogicProvider;
            _jwtService = jwtService;
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateRole([FromBody] RolemasterDto rolemasterDto)
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
            rolemasterDto.Createdby = userId;
            var result = await _IRolemasterBusinessLogicProvider.CreateRoleAsync(rolemasterDto);
            if (!result.Success)
                return BadRequest(new ApiResponse<string>(null, false, result.Message));

            return Ok(new ApiResponse<RolemasterDto>(result.Data, true, result.Message));
        }
        [HttpPut("update")]
        public async Task<IActionResult> UpdateRole([FromBody] RolemasterDto rolemasterDto)
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
            //rolemasterDto.Modifyby = userId;
            var result = await _IRolemasterBusinessLogicProvider.UpdateRoleAsync(rolemasterDto);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetRoleById(long id)
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
            var result = await _IRolemasterBusinessLogicProvider.GetRoleByIdAsync(id);
            return result.Success ? Ok(result) : NotFound(result);
        }

        [HttpGet("list")]
        public async Task<IActionResult> GetRoles()
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
            var result = await _IRolemasterBusinessLogicProvider.GetRolesAsync();
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRole(long id)
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
            var result = await _IRolemasterBusinessLogicProvider.DeleteRoleAsync(id);
            return result.Success ? Ok(result) : NotFound(result);
        }
    }
}

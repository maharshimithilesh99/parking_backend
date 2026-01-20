using Microsoft.AspNetCore.Mvc;
using ParkingApp.API.Helpers;
using ParkingApp.Businesslogic.IRepositories;
using ParkingApp.Businesslogic.Repositories;
using ParkingApp.Businesslogic.Services;
using ParkingApp.Infrastructure.DTO.Master;
using System.Security.Claims;

namespace ParkingApp.API.Controllers.Master
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolemenuController : ControllerBase
    {
        private IRolemenumappingBusinessLogicProvider _IRolemenumappingBusinessLogicProvider;
        private readonly JwtTokenService _jwtService;
        public RolemenuController(IRolemenumappingBusinessLogicProvider rolemenumappingBusinessLogicProvider, JwtTokenService jwtService)
        {
            _IRolemenumappingBusinessLogicProvider = rolemenumappingBusinessLogicProvider;
            _jwtService = jwtService;
        }
        [HttpPost("AssignMenus")]
        public async Task<IActionResult> AssignMenusToRole([FromBody] RolemenumappingDto RolemenumappingDto)
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
            RolemenumappingDto.Createdby = userId;
            var result = await _IRolemenumappingBusinessLogicProvider.CreateAssignMenusAsync(RolemenumappingDto);
            if (!result.Success)
                return BadRequest(new ApiResponse<string>(null, false, result.Message));

            return Ok(new ApiResponse<RolemenumappingDto>(result.Data, true, result.Message));
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAssignMenu(long id)
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
            var result = await _IRolemenumappingBusinessLogicProvider.DeleteAssignMenuAsync(id);
            return result.Success ? Ok(result) : NotFound(result);
        }
    }
}

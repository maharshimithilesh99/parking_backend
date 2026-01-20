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
    public class CompanycontactpersonController : ControllerBase
    {
        private ICompanycontactpersonBusinessLogicProvider _ICompanycontactpersonBusinessLogicProvider;
        private readonly JwtTokenService _jwtService;
        public CompanycontactpersonController(ICompanycontactpersonBusinessLogicProvider companycontactpersonBusinessLogicProvider, JwtTokenService jwtService)
        {
            _ICompanycontactpersonBusinessLogicProvider = companycontactpersonBusinessLogicProvider;
            _jwtService = jwtService;
        }
        [HttpPost("create")]
        public async Task<IActionResult> CreateCompanycontactperson([FromBody] CompanycontactpersonDto companycontactpersonDto)
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
            companycontactpersonDto.Createdby = userId;
            var result = await _ICompanycontactpersonBusinessLogicProvider.CreateCompanycontactpersonAsync(companycontactpersonDto);
            if (!result.Success)
                return BadRequest(new ApiResponse<string>(null, false, result.Message));

            return Ok(new ApiResponse<CompanycontactpersonDto>(result.Data, true, result.Message));
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
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
            var result = await _ICompanycontactpersonBusinessLogicProvider.GetCompanycontactpersonByIdAsync(id);
            return result.Success ? Ok(result) : NotFound(result);
        }
        [HttpGet("list")]
        public async Task<IActionResult> GetAll()
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
            var result = await _ICompanycontactpersonBusinessLogicProvider.GetCompanycontactpersonsAsync();
            return Ok(result);
        }
        [HttpPut("update")]
        public async Task<IActionResult> Update(
            [FromBody] CompanycontactpersonDto dto)
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
            var result = await _ICompanycontactpersonBusinessLogicProvider.UpdateCompanycontactpersonAsync(dto);
            return result.Success ? Ok(result) : BadRequest(result);
        }
        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete(int id)
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
            var result = await _ICompanycontactpersonBusinessLogicProvider.DeleteCompanycontactpersonAsync(id);
            return result.Success ? Ok(result) : BadRequest(result);
        }
    }
}

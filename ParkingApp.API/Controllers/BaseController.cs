using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using ParkingApp.API.Filters;
using ParkingApp.API.Services;
using ParkingApp.Data.UnitOfWork;
using System.IdentityModel.Tokens.Jwt;

namespace ParkingApp.API.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [ValidateModelState]
    public abstract class BaseController : ControllerBase
    {
        protected readonly IUnitOfWork Uow;
        protected readonly JwtTokenService JwtService;

        protected BaseController(IUnitOfWork uow, JwtTokenService jwtService)
        {
            Uow = uow;
            JwtService = jwtService;
        }

        protected string GetUserIdFromToken()
        {
            var authHeader = HttpContext.Request.Headers["Authorization"].ToString();

            if (!authHeader.StartsWith("Bearer ", StringComparison.OrdinalIgnoreCase))
                throw new UnauthorizedAccessException("Invalid Authorization header");

            var tokenStr = authHeader.Substring("Bearer ".Length).Trim();

            var handler = new JwtSecurityTokenHandler();

            if (!handler.CanReadToken(tokenStr))
                throw new SecurityTokenMalformedException("Invalid JWT format");

            var token = handler.ReadJwtToken(tokenStr);

            return token.Claims.First(c => c.Type == JwtRegisteredClaimNames.Sub).Value;
        }

    }
}

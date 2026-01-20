using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ParkingApp.API.Filters;
using System.IdentityModel.Tokens.Jwt;

namespace ParkingApp.API.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [ValidateModelState]
    public abstract class BaseController : ControllerBase
    {

        protected string GetUserIdFromToken()
        {
            var authHeader = HttpContext.Request.Headers["Authorization"].ToString();
            var tokenStr = authHeader.Replace("Bearer ", "");
            var handler = new JwtSecurityTokenHandler();
            var token = handler.ReadJwtToken(tokenStr);

            return token.Claims.First(c => c.Type == "nameid").Value;
        }
    }
}

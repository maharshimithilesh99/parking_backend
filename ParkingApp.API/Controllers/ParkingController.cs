using Microsoft.AspNetCore.Mvc;
using ParkingApp.API.Services;
using ParkingApp.Data.UnitOfWork;

namespace ParkingApp.API.Controllers
{
    [ApiController]
    [Route("api/parking")]
    public class ParkingController : BaseController
    {
        public ParkingController(IUnitOfWork uow, JwtTokenService jwtService)
            : base(uow, jwtService)
        {
        }

        [HttpGet("my-data")]
        public IActionResult GetMyData()
        {
            var userId = GetUserIdFromToken();
            return Ok(new { userId });
        }
    }
}

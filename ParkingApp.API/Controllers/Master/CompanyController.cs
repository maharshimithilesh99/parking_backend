using Microsoft.AspNetCore.Mvc;

namespace ParkingApp.API.Controllers.Master
{
    public class CompanyController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

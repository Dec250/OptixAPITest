using Microsoft.AspNetCore.Mvc;

namespace Optix_Technical_Test.Controllers
{
    public class HomeController : Microsoft.AspNetCore.Mvc.Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

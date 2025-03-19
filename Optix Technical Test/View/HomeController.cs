using Microsoft.AspNetCore.Mvc;

namespace Optix_Technical_Test.View.Shared
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

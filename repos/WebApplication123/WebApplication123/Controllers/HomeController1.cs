using Microsoft.AspNetCore.Mvc;

namespace WebApplication123.Controllers
{
    public class HomeController1 : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

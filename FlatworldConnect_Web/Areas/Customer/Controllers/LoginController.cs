using Microsoft.AspNetCore.Mvc;

namespace FlatworldConnect_Web.Areas.Customer.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

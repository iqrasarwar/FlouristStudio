using Microsoft.AspNetCore.Mvc;

namespace FlouristStudio.Controllers
{
    public class CartController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

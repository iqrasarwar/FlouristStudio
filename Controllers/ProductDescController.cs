using Microsoft.AspNetCore.Mvc;

namespace FlouristStudio.Controllers
{
    public class ProductDescController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

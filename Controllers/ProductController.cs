using Microsoft.AspNetCore.Mvc;

namespace FlouristStudio.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

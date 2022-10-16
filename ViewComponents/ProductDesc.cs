using FlouristStudio.Models;
using Microsoft.AspNetCore.Mvc;

namespace FlouristStudio.ViewComponents
{
    public class ProductDesc : ViewComponent
    {
        
        public IViewComponentResult Invoke(Product ProdcutObj)
        {
            ViewData["id"] = ProdcutObj.Id;
            return View();
        }
    }
}

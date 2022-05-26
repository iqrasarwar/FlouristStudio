using FlouristStudio.Models;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace FlouristStudio.Controllers3
{
    public class SignUpController : Controller
    {
        [HttpGet]
        public IActionResult SignUp()
        {
            return View();
        }
        [HttpPost]
        public IActionResult SignUp(SignUp s)
        {
            var uniqueUser = DataBase.UniqueUser(s);
            if (ModelState.IsValid && uniqueUser)
            {
                DataBase.RegisterNewUser(s);
                ModelState.Clear();
                return View();
            }
            else
            {
                if(!uniqueUser)
                ModelState.AddModelError(string.Empty, "UserName is already Taken!");
                return View("SignUpError");
            }
        }
        [HttpPost]
        public IActionResult SignIn(SignIn user)
        {
            if(ModelState.IsValid)
            {
                if (DataBase.VerifyUser(user))
                {
                    ModelState.Clear();
                    ViewBag.List = DataBase.GetUsers();
                    return View("UsersList");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Invalid credentials!");
                    return View("SignUp");
                }
            }
            else
                return View("SignUp");
        }
    }
}

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
        private static List<ValidationResult> ValidateModel(object model)
        {
            var validationResults = new List<ValidationResult>();
            var ctx = new ValidationContext(model, null, null);
            Validator.TryValidateObject(model, ctx, validationResults, true);
            return validationResults;
        }
        [HttpPost]
        public IActionResult SignUp(SignUp s)
        {
            //string Name,string UserName,string Email,string Password,string ConfirmPassword
            //SignUp s = new(Name, UserName, Email, Password,ConfirmPassword);
            //var res = ValidateModel(s);
           // var uniqueUser = DataBase.UniqueUser(s);
            if (ModelState.IsValid )//&& res.Count <= 0 && uniqueUser)
            {
                DataBase.RegisterNewUser(s);
                ModelState.Clear();
                return View();
            }
            else
            {
                /*foreach (ValidationResult result in res)
                    if (result.ToString() == "Password and Confirm Password do not match")
                        ModelState.AddModelError(string.Empty, result.ToString());*/
                return View("SignUpError");
            }
        }
        [HttpPost]
        public IActionResult SignIn(string UserName, string Password)
        {
            SignIn user = new(UserName, Password);
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

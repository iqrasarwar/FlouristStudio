using System.ComponentModel.DataAnnotations;

namespace FlouristStudio.Models
{
    public class SignUp
    {
        public SignUp()
        {

        }
        public SignUp(string name, string userName, string email, string password,string confrimPass)
        {
            Name = name;
            UserName = userName;
            Email = email;
            Password = password;
            ConfirmPassword = confrimPass;
        }

        [Required(ErrorMessage = "Name is required.")]
        [StringLength(50)]
        public string? Name { get; set; }

        [Required(ErrorMessage = "User Name is required.")]
        [StringLength(50)]
        public string? UserName { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        [DataType(DataType.Password)]
        public string? Password { get; set; }

        [Required(ErrorMessage = "Confirm Password is required.")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Password and Confirm Password do not match")]
        public string? ConfirmPassword { get; set; }
    }
}

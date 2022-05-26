using System.ComponentModel.DataAnnotations;

namespace FlouristStudio.Models
{
    public class SignIn
    {
        [Required(ErrorMessage = "Please enter Your Name")]
        [StringLength(50)]
        public string? UserName { get; set; }

        [Required(ErrorMessage = "Please enter Password")]
        [DataType(DataType.Password)]
        public string? Password { get; set; }

        public SignIn(string userName, string password)
        {
            this.UserName = userName;
            this.Password = password;
        }
        public SignIn()
        {
        }
    }
}

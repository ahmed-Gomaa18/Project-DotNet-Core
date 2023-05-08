using System.ComponentModel.DataAnnotations;

namespace Project.ViewModel
{
    public class RegisterAccountViewModel
    {
        [Required]
        public string UserName { get; set; }

        [DataType(DataType.EmailAddress)]
        [Required]
        public string Email { get; set; }

        [DataType(DataType.Password)]
        [Required]
        public string Password { get; set; }

        [Compare("Password",ErrorMessage = "Password Not Match With ConfirmPassword.")]
        [DataType(DataType.Password)]
        [Required]
        public string ConfirmPassword { get; set; }
    }
}

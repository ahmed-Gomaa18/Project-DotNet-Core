using System.ComponentModel.DataAnnotations;

namespace Project.ViewModel
{
    public class LoginAccountViewModel
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public bool RememberMe { get; set; }


    }
}

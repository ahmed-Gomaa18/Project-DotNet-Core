using System.ComponentModel.DataAnnotations;

namespace Project.ViewModel
{
    public class RoleViewModel
    {
        [Required]
        [MinLength(3)]
        public string RoleName { get; set; }
    }
}

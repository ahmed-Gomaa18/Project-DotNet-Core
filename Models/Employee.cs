using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project.Models
{
    public class Employee
    {
        public int ID { get; set; }
        [Required, MinLength(4, ErrorMessage = "Name Must be More than 4 Chars.")]
        public string Name { get; set; }
        [Required, MinLength(7, ErrorMessage = "Address Must be More than 7 Chars.")]
        public string Address { get; set; }
        [DefaultValue("Junior")]
        [Required]
        public string Level { get; set; }
        [Required]
        public string Gender { get; set; }
        public double Salary { get; set; }


        [ForeignKey("Category")]
        [Display(Name = "Category Name")]
        public int CategoryID { get; set; }
        public virtual Category Category { get; set; }



    }
}

using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Project.Models
{
    public class Category
    {
        public int ID { get; set; }
        [Required, MinLength(3, ErrorMessage="MinLength Of Category is Three Char.")]
        public string Name { get; set; }
        public string Description { get; set; }


        public virtual ICollection<Employee> Employees { get; set; }
    }
}

using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Project.Models
{
    public partial class Department
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string? Manager { get; set; }
        public ICollection<Instructor> Instructors { get; set; }

    }

}

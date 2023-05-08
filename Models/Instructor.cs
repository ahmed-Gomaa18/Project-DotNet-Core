using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project.Models
{
    // For Database First 
    public partial class Instructor
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public double Salary { get; set; }
        public string? Image { get; set; }

        [ForeignKey("Department")]
        public int DepartmentID { get; set; }
        public Department Department { get; set; }

    }
}

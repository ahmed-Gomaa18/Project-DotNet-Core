using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project.Models
{
    public class Course
    {
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        public int Degree { get; set; }
        public int? MinDegree { get; set; }

        [ForeignKey("Department")]
        public int DepartmentID { get; set; }
        public Department Department { get; set; }
    }
}

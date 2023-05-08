using System.ComponentModel.DataAnnotations.Schema;

namespace Project.Models
{
    public class Trainee
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public double? Grad { get; set; }

        [ForeignKey("Department")]
        public int DepartmentID { get; set; }
        public Department Department { get; set; }
    }
}

using System.ComponentModel.DataAnnotations.Schema;

namespace Project.Models
{
    public class CourseResult
    {
        public int ID { get; set; }
        public double Degree { get; set; }


        [ForeignKey("Course")]
        public int CourseID { get; set; }
        
        
        [ForeignKey("Trainee")]
        public int TraineeID { get; set; }

        public Trainee Trainee { get; set; }
        public Course Course { get; set; }


    }
}

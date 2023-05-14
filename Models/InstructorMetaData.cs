using Microsoft.AspNetCore.Mvc;
using Project.Models.ValidateAttribute;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Project.Models
{
    [ModelMetadataType(typeof(InstructorMetaData))]
    public partial class Instructor
    {
        // .........
    }
    public class InstructorMetaData
    {
        public int ID { get; set; }

        [Remote(action:"NameExist", controller:"Instructor",AdditionalFields ="ID", ErrorMessage ="This Name Is Already Exist")]
        [MinLength(5, ErrorMessage = "Length Of Name Must be More Than 5 Char.")]
        [Required]
        [Display(Name = "Instructor Name")]
        public string Name { get; set; }
      
        [MinLength(5, ErrorMessage = "Length Of Address Must be More Than 5 Char.")]
        // Custom Validation
        [ValidateAddress]
        public string Address { get; set; }
        [Range(1000, 30000)]
        public double Salary { get; set; }
        [RegularExpression("[^\\s]+(.*?)\\.(jpg|jpeg|png|gif|JPG|JPEG|PNG|GIF)$", ErrorMessage = "Invalid Image")]
        public string? Image { get; set; }


        [Display(Name = "Department")]
        public int DepartmentID { get; set; }
    }
}

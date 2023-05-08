using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Project.Models
{
    [ModelMetadataType(typeof(DepartmentMetaData))]
    public partial class Department
    {
        // .....
    }
    public class DepartmentMetaData
    {
        [Required]
        public string Name { get; set; }

        [MinLength(4, ErrorMessage ="Manager Name Must Be More Than 4 Char")]
        [Required]

        [Display(Name ="Manager Name")]
        public string? Manager { get; set; }
    }
}

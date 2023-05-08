using Microsoft.AspNetCore.Mvc;
using Project.Models;
using Project.Services;
using System.Collections.Generic;
using System.Linq;

namespace Project.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly IDepartmentRepository departmentRepo;
        private readonly IInstructorRepository instructorRepo;
        
        // Inject By Ioc Container
        public DepartmentController( IDepartmentRepository _departmentRepo, IInstructorRepository _instructorRepo)
        {
            departmentRepo = _departmentRepo; 
            instructorRepo = _instructorRepo; 
        }

        public IActionResult Index()
        {
            List<Department> departments = departmentRepo.getAll();

            return View(departments);
        }

        public IActionResult Edit([FromRoute]int id)
        {
            Department dept = departmentRepo.getById(id);

            return View(dept);

        }

        public IActionResult SaveEdit([FromRoute]int id, Department NewDept)
        {
            // Check Validation
            if(ModelState.IsValid == true)
            {
                departmentRepo.Update(id, NewDept);
                return RedirectToAction("Index");
            }

            return View("Edit", NewDept);

        }

        // For Ajax Request
        public IActionResult GetInstructorByDeptID(int id)
        {
            List<Instructor> instructors = instructorRepo.getAllByDeptId(id);
            return PartialView("_ListOfInstructor", instructors);
        }

    }
}

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project.Models;
using Project.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Project.Controllers
{
    public class InstructorController : Controller
    {   
        private readonly IInstructorRepository instructorRepo;
        private readonly IDepartmentRepository departmentRepo;

        // Inject By Ioc Container
        public InstructorController(IInstructorRepository _instructorRepo, IDepartmentRepository _departmentRepo)
        {
            instructorRepo = _instructorRepo; //new InstructorRepository();
            departmentRepo = _departmentRepo; //new DepartmentRepository();
        }

        public IActionResult NameExist(string name, int ID)
        {
            Instructor instructor = instructorRepo.getByName(name);
            // Create New Instructor
            if (ID == 0)
            {
                if (instructor == null)
                {
                    return Json(true);
                }
                else
                {
                    return Json(false);
                }
            }
            else // Update Instructor
            {
                if (instructor == null)
                {
                    return Json(true);
                }
                else
                {
                    if (instructor.ID == ID)
                    {
                        // This Name For The Current Instructor
                        return Json(true);
                    }
                    else
                    {
                        return Json(false);
                    }
                }
            }

        }
        [Authorize]
        public IActionResult Index()
        {
            
            List<Instructor> Instructors = instructorRepo.getAllWithDepartments();
            
            return View("index", Instructors);

        }

        public IActionResult Details([FromRoute]int id)
        {
            var Instructor = instructorRepo.getById(id);

            return View("Details", Instructor);
        }

        public IActionResult Add()
        {
            List<Department> depts = departmentRepo.getAll();
            ViewData["depts"] = depts;
            return View();
        }

        public IActionResult SaveAdd(Instructor NewInst)
        {
            // Validate 
            if(ModelState.IsValid == true)
            {
                // Add new Instructor To DB
                instructorRepo.Create(NewInst);
                return RedirectToAction("Index");
            }
            // Send All Departments
            List<Department> depts = departmentRepo.getAll();
            ViewData["depts"] = depts;

            return View("Add", NewInst);


        }

        public IActionResult Edit([FromRoute]int id)
        {
            // Get Instructor
            Instructor instructor = instructorRepo.getById(id);
            // Get All Department & Send to view in ViewData
            List<Department> depts = departmentRepo.getAll();
            ViewData["depts"] = depts;
            return View(instructor);
        }

        public IActionResult SaveEdit([FromRoute]int id, Instructor NewInst)
        {
            // Validate
            if(ModelState.IsValid == true)
            {
                instructorRepo.Update(id, NewInst);
                return RedirectToAction("Index");
            }

            List<Department> depts = departmentRepo.getAll();
            ViewData["depts"] = depts;

            return View("Edit", NewInst);



        }

        public IActionResult Delete([FromRoute]int id)
        {
            try
            {
                instructorRepo.Delete(id);
                return RedirectToAction("Index");
            
            }catch(Exception ex)
            {
                // Send Exception
                ModelState.AddModelError("Exception", ex.InnerException.Message);
                return View("Details");
            }
        }

    }
}

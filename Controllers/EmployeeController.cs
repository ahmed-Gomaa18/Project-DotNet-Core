using Microsoft.AspNetCore.Mvc;
using Project.Models;
using Project.Services;
using System;
using System.Collections.Generic;

namespace Project.Controllers
{
    public class Levels
    {
        public string Name { get; set; }
    }
    public class Gender
    {
        public string Name { get; set; }
    }

    public class EmployeeController : Controller
    {
        private IEmployeeRepository employeeRepository;
        private ICategoryRepository categoryRepository;
        public EmployeeController(IEmployeeRepository _employeeRepository, ICategoryRepository _categoryRepository)
        {
            employeeRepository = _employeeRepository;
            categoryRepository = _categoryRepository;
        }


        public IActionResult Index()
        {
            List<Employee> employees = employeeRepository.GetAllWithCategories();
            return View(employees);
        }

        [HttpGet]
        public IActionResult Add() 
        {
            List<Category> categories = categoryRepository.GetAll();
            List<Levels> levels = new List<Levels> { 
                new Levels {Name = "Jonuior"},
                new Levels {Name = "Mid Level"},
                new Levels {Name = "Sinior"}
            };
            List<Gender> genders = new List<Gender>
            {
                new Gender { Name = "Male"},
                new Gender { Name = "Female"}
            };

            ViewData["categories"] = categories;
            ViewData["levels"] = levels;
            ViewData["genders"] = genders;

            return View();
        }

        [HttpPost]
        public IActionResult Add(Employee employee) 
        {
            if(ModelState.IsValid)
            {
                employeeRepository.Create(employee);
                return RedirectToAction("Index");
            }

            List<Category> categories = categoryRepository.GetAll();
            List<Levels> levels = new List<Levels> {
                new Levels {Name = "Jonuior"},
                new Levels {Name = "Mid Level"},
                new Levels {Name = "Sinior"}
            };
            List<Gender> genders = new List<Gender>
            {
                new Gender { Name = "Male"},
                new Gender { Name = "Female"}
            };

            ViewData["categories"] = categories;
            ViewData["levels"] = levels;
            ViewData["genders"] = genders;

            return View(employee);
        }


        [HttpGet]
        public IActionResult Edit(int id)
        {
            List<Category> categories = categoryRepository.GetAll();
            List<Levels> levels = new List<Levels> {
                new Levels {Name = "Jonuior"},
                new Levels {Name = "Mid Level"},
                new Levels {Name = "Sinior"}
            };
            List<Gender> genders = new List<Gender>
            {
                new Gender { Name = "Male"},
                new Gender { Name = "Female"}
            };

            ViewData["categories"] = categories;
            ViewData["levels"] = levels;
            ViewData["genders"] = genders;

            Employee employee = employeeRepository.GetByID(id);
            return View(employee);
        }

        [HttpPost]
        public IActionResult Edit([FromRoute]int id, Employee employee)
        {
            if(ModelState.IsValid)
            {
                employeeRepository.Update(id, employee);
                return RedirectToAction("Index");
            }

            List<Category> categories = categoryRepository.GetAll();
            List<Levels> levels = new List<Levels> {
                new Levels {Name = "Jonuior"},
                new Levels {Name = "Mid Level"},
                new Levels {Name = "Sinior"}
            };
            List<Gender> genders = new List<Gender>
            {
                new Gender { Name = "Male"},
                new Gender { Name = "Female"}
            };

            ViewData["categories"] = categories;
            ViewData["levels"] = levels;
            ViewData["genders"] = genders;

            return View(employee);
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            Employee employee = employeeRepository.GetByID(id);
            return View(employee);
        }
        
        public IActionResult Delete([FromRoute] int id)
        {
            try
            {
                employeeRepository.Delete(id);
                return RedirectToAction("Index");

            }
            catch (Exception ex)
            {
                // Send Exception
                ModelState.AddModelError("Exception", ex.InnerException.Message);
                return View("Details");
            }
        }
    }
}

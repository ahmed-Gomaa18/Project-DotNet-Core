using Microsoft.AspNetCore.Mvc;
using Project.Models;
using Project.Services;
using System.Collections.Generic;

namespace Project.Controllers
{
    public class CategoryController : Controller
    {
        private ICategoryRepository categoryRepository;
        public CategoryController(ICategoryRepository _categoryRepository)
        {
            categoryRepository = _categoryRepository;
        }

        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(Category category)
        {
            if (ModelState.IsValid)
            {
                categoryRepository.Create(category);
                return RedirectToAction("Index");
            }

            return View(category);
        }

        public ActionResult Index()
        {
            List<Category> categories = categoryRepository.GetAll();

            return View(categories);
        }
    }
}

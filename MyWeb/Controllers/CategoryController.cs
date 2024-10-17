using Microsoft.AspNetCore.Mvc;
using MyWeb.Data;
using MyWeb.Models;
using System.Collections.Generic;
using System.Linq;

namespace MyWeb.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _db;

        // Constructor
        public CategoryController(ApplicationDbContext db)
        {
            _db = db;
        }

        // Action method for the Index view (List of Categories)
        public IActionResult Index()
        {
            // Get a list of categories from the database
            List<Category> objCategoryList = _db.Categories.ToList();
            return View(objCategoryList);
        }

        // GET: Action method to show the form for creating a new category
        public IActionResult Create()
        {
            return View();
        }

      
        [HttpPost]
        [ValidateAntiForgeryToken] 
        public IActionResult Create(Category obj)
        {
          
            if (ModelState.IsValid)
            {
                // Add the new category to the database
                _db.Categories.Add(obj);
                _db.SaveChanges(); 

               
                return RedirectToAction("Index");
            }

          
            return View(obj);
        }
    }
}

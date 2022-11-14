using HealthyFood;
using HealthyFood.Data;
using HealthyFood.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HealthyFood.Controllers
{
    [Authorize(Roles = WC.AdminRole)]
    public class CategoryController : Controller
    {


        private readonly ApplicationDbContext _db;

        public CategoryController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<Category> obList = _db.Category;
            return View(obList);
        }

        //Get - Create
        public IActionResult Create()
        {
            return View();
        }
        //Post-Create
        [HttpPost]
        [ValidateAntiForgeryToken] //токен для безопасности данных 
        public IActionResult Create(Category obj)
        {
            if (ModelState.IsValid)
            {
                _db.Category.Add(obj);//add to DataBase;
                _db.SaveChanges();//save to DataBase;
                return RedirectToAction("Index");// Redirect to methood "Index"
            }
            return View(obj);

        }

        //Get - Edit
        public IActionResult Edit(int? Id)
        {
            if (Id == null || Id == 0)
            {
                return NotFound();
            }
            var obj = _db.Category.Find(Id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }
        //Post-Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Category obj)
        {
            if (ModelState.IsValid)
            {
                _db.Category.Update(obj);//add to DataBase;
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);

        }
        //Get-Delete
        public IActionResult Delete(int? Id)
        {
            if (Id == null || Id == 0)
            {
                return NotFound();
            }
            var obj = _db.Category.Find(Id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }
        //Post - delete
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(Category category)
        {
            var obj = _db.Category.Find(category.CategoryId);
            if (obj == null)
            {
                return NotFound();
            }
            _db.Category.Remove(obj);//delete to DataBase;
            _db.SaveChanges();
            return RedirectToAction("Index");


        }
    }
}

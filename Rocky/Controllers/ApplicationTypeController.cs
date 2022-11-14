using HealthyFood;
using HealthyFood.Data;
using HealthyFood.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HealthyFood.Controllers
{
    [Authorize(Roles = WC.AdminRole)]
    public class ApplicationTypeController : Controller
    {
        private readonly ApplicationDbContext _db;
        public ApplicationTypeController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<ApplicationType> obList = _db.ApplicationTypes;

            return View(obList);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ApplicationType obj)
        {
            if (ModelState.IsValid)
            {
                _db.ApplicationTypes.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return NotFound();
        }

        //Get - Edit
        public IActionResult Edit(int? Id)
        {
            if (Id == null || Id == 0)
            {
                return NotFound();
            }
            var obj = _db.ApplicationTypes.Find(Id);
            if (Id == null)
            {
                return NotFound();
            }
            return View(obj);
        }
        //Post-delete
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(ApplicationType obj)
        {
            if (ModelState.IsValid)
            {
                _db.ApplicationTypes.Update(obj);
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
            var obj = _db.ApplicationTypes.Find(Id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }
        //Post - delete
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(ApplicationType applicationType)
        {
            var obj = _db.ApplicationTypes.Find(applicationType.Id);
            if (obj == null) return NotFound();
            _db.ApplicationTypes.Remove(obj);//delete to DataBase;
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}


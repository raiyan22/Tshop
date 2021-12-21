using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tshop.Data;
using Tshop.Models;

namespace Tshop.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SizeController : Controller
    {
        private ApplicationDbContext _db;

        public SizeController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            return View(_db.Size.ToList());
        }

        // GET Create action method
        public ActionResult Create()  // add view
        {
            return View();
        }

        // POST Create action Method
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Size size)
        {
            if (ModelState.IsValid)
            {
                _db.Size.Add(size);
                await _db.SaveChangesAsync();
                TempData["save"] = "New Size Added";
                return RedirectToAction(nameof(Index));
            }
            return View(size);
        }

        /////////////////////////////

        // GET Edit action method
        public ActionResult Edit(int? id) // add view
        {
            if (id == null)
            {
                return NotFound();
            }
            var size = _db.Size.Find(id);
            if (size == null)
            {
                return NotFound();
            }
            return View(size);
        }

        // POST Edit action Method
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Size size)
        {
            if (ModelState.IsValid)
            {
                _db.Update(size);
                await _db.SaveChangesAsync();
                TempData["edit"] = "Size Updated";
                return RedirectToAction(nameof(Index));
            }
            return View(size);
        }

        /////////////////////////////

        // GET Details action method
        public ActionResult Details(int? id) // add view
        {
            if (id == null)
            {
                return NotFound();
            }
            var size = _db.Size.Find(id);
            if (size == null)
            {
                return NotFound();
            }
            return View(size);
        }

        // POST Details action Method
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Details(Size size)
        {
            return View(nameof(Index));
        }

        /////////////////////////////

        // GET Delete action method
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var size = _db.Size.Find(id);
            if (size == null)
            {
                return NotFound();
            }
            return View(size);
        }

        // POST Edit action Method
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int? id, Size size)  // add view
        {
            if (id == null)
            {
                return NotFound();
            }
            if (id != size.Id)
            {
                return NotFound();
            }
            var productType = _db.Size.Find(id);
            if (productType == null)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                _db.Remove(productType);
                await _db.SaveChangesAsync();
                TempData["delete"] = "Deleted!";
                return RedirectToAction(nameof(Index));
            }
            return View(size);
        }

    }
}

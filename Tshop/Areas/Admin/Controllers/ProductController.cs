using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Tshop.Data;
using Tshop.Models;

namespace Tshop.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private ApplicationDbContext _db;
        private IWebHostEnvironment _he;

        public ProductController(ApplicationDbContext db, IWebHostEnvironment he)
        {
            _db = db;
            _he = he;
        }

        public IActionResult Index()  // add view
        {
            return View(_db.Products.Include(item=>item.ProductTypes).Include(i=>i.Size).ToList());
        }

        // GET Create Method
        public IActionResult Create() // add view
        {
            ViewData["productTypeId"] = new SelectList(_db.ProductTypes.ToList(), "ID", "ProductType"); // producttype.cs class ref
            ViewData["SizeId"] = new SelectList(_db.Size.ToList(), "Id", "ProductSize");
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Create(Products products, IFormFile image)
        {
            if (ModelState.IsValid)
            {
                if (image != null)
                {
                    var name = Path.Combine(_he.WebRootPath + "/images", Path.GetFileName(image.FileName));
                    await image.CopyToAsync(new FileStream(name, FileMode.Create));
                    products.Image = "images/" + image.FileName;
                }
                if (image == null)
                {
                    products.Image = "images/no_img.PNG";
                }

                _db.Products.Add(products);
                await _db.SaveChangesAsync();
                TempData["save"] = "New Product Saved Successfully";
                return RedirectToAction(nameof(Index));
            }
            return View(products);
        }

        //GET Edit Action Method

        public ActionResult Edit(int? id)
        {
            ViewData["productTypeId"] = new SelectList(_db.ProductTypes.ToList(), "ID", "ProductType"); // producttype.cs class ref
            ViewData["SizeId"] = new SelectList(_db.Size.ToList(), "Id", "ProductSize");
            if (id == null)
            {
                return NotFound();
            }

            var product = _db.Products.Include(c => c.ProductTypes).Include(c => c.Size)
                .FirstOrDefault(c => c.Id == id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }





    }
}

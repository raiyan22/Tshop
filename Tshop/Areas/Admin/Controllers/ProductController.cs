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

        // GET Index action method
        public IActionResult Index()  // add view
        {
            return View(_db.Products
                            .Include(item=>item.ProductTypes)
                                    .Include(i=>i.Size)
                                           .ToList());
        }

        //POST Index action method
        [HttpPost]
        public IActionResult Index(decimal? lowAmount, decimal? largeAmount)
        {
            var products = _db.Products.
                                Include(c => c.ProductTypes).
                                    Include(c => c.Size)
                                        .Where(c => c.Price >= lowAmount && c.Price <= largeAmount)
                                            .ToList();
            if (lowAmount == null || largeAmount == null)
            {
                products = _db.Products.
                                Include(c => c.ProductTypes)
                                       .Include(c => c.Size)
                                            .ToList();
            }
            return View(products);
        }


        // GET Create Method
        public IActionResult Create() // add view
        {
            ViewData["productTypeId"] = new SelectList(_db.ProductTypes.ToList(), "ID", "ProductType"); // producttype.cs class ref
            ViewData["SizeId"] = new SelectList(_db.Size.ToList(), "Id", "ProductSize");
            return View();
        }


        //Post Create method
        [HttpPost]
        public async Task<IActionResult> Create(Products product, IFormFile image)
        {
            if (ModelState.IsValid)
            {
                var searchProduct = _db.Products.FirstOrDefault(c => c.Name == product.Name);
                if (searchProduct != null)
                {
                    ViewBag.message = "This Product is already exists";
                    ViewData["productTypeId"] = new SelectList(_db.ProductTypes.ToList(), "ID", "ProductType"); // producttype.cs class ref
                    ViewData["SizeId"] = new SelectList(_db.Size.ToList(), "Id", "ProductSize");
                    return View(product);
                }

                if (image != null)
                {
                    var name = Path.Combine(_he.WebRootPath + "/Images", Path.GetFileName(image.FileName));
                    await image.CopyToAsync(new FileStream(name, FileMode.Create));
                    product.Image = "Images/" + image.FileName;
                }

                if (image == null)
                {
                    product.Image = "Images/noimage.PNG";
                }
                _db.Products.Add(product);
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(product);
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

            var product = _db.Products
                            .Include(c => c.ProductTypes)
                                .Include(c => c.Size)
                                    .FirstOrDefault(c => c.Id == id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        //POST Edit Action Method
        [HttpPost]
        public async Task<IActionResult> Edit(Products products, IFormFile image)
        {
            if (ModelState.IsValid)
            {
                if (image != null)
                {
                    var name = Path.Combine(_he.WebRootPath + "/Images", Path.GetFileName(image.FileName));
                    await image.CopyToAsync(new FileStream(name, FileMode.Create));
                    products.Image = "Images/" + image.FileName;
                }

                if (image == null)
                {
                    products.Image = "images/no_img.PNG";
                }
                _db.Products.Update(products);
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(products);
        }

        //GET Details Action Method
        public ActionResult Details(int? id)
        {

            if (id == null)
            {
                return NotFound();
            }

            var product = _db.Products
                            .Include(c => c.ProductTypes)
                                .Include(c => c.Size)
                                    .FirstOrDefault(c => c.Id == id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        //GET Delete Action Method

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = _db.Products
                            .Include(c => c.Size)
                                .Include(c => c.ProductTypes)
                                    .Where(c => c.Id == id)
                                        .FirstOrDefault();
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        //POST Delete Action Method

        [HttpPost]
        [ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirm(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = _db.Products.FirstOrDefault(c => c.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            _db.Products.Remove(product);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }


    }
}

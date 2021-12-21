using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tshop.Data;

namespace Tshop.Areas.Customer.Controllers
{
    [Area("Admin")]
    public class ProductTypesController : Controller
    {
        private ApplicationDbContext _db;

        public ProductTypesController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            var data = _db.ProductTypes.ToList();
            return View(_db.ProductTypes.ToList());
        }

        // Create get action method
        public ActionResult Create()
        {
            return View();
        }

    }
}

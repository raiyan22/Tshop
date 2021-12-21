using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tshop.Data;
using Tshop.Models;

namespace Tshop.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private ApplicationDbContext _db;

        public ProductController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()  // add view
        {
            return View(_db.Products.Include(item=>item.ProductTypes).Include(i=>i.Size).ToList());
        }
    }
}

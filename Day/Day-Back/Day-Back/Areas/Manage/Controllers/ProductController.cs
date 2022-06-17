using Day_Back.DAL;
using Day_Back.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Day_Back.Areas.Manage.Controllers
{
    [Area("Manage")]
    public class ProductController : Controller
    {
        private readonly IWebHostEnvironment _env;
        private readonly AppDbContext _context;

        public ProductController(AppDbContext context,IWebHostEnvironment env)
        {
            _env = env;
            _context = context;
        }
        public IActionResult Index()
        {
            return View(_context.Products.Include(x=>x.ProductImage).Include(x => x.Datas).ToList());
        }
        public IActionResult Create()
        {
            _context.Products.Include(x => x.ProductImage).Include(x=>x.Datas).ToList();
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Product product)
        {
            
            if (!ModelState.IsValid) return View(product);
            string filename = product.ProductImage.Photo.FileName;
            string newfilename = Guid.NewGuid().ToString() + filename;
            string path = Path.Combine(_env.WebRootPath, "assets", "image", "portfolio", newfilename);
            using(FileStream fs= new FileStream(path, FileMode.Create))
            {
                product.ProductImage.Photo.CopyTo(fs);
            }
            product.ProductImage.Image = newfilename;
            _context.Products.Add(product);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Edit(int? id)
        {
            return RedirectToAction(nameof(Index));
        }
        [HttpPost,ValidateAntiForgeryToken]
        public IActionResult Edit(Product product)
        {
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Delete(int? id)
        {
            Product product = _context.Products.Include(x => x.ProductImage).Include(x => x.Datas).FirstOrDefault(x => x.Id == id);
            _context.Products.Remove(product);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}

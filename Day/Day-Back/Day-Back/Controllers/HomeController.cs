using Day_Back.DAL;
using Day_Back.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Day_Back.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;

        public HomeController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            HomevM homevM = new HomevM
            {
                ProductImages=_context.ProductImages.ToList(),
                Products = _context.Products.Include(x => x.ProductImage).ToList(),
                Datas=_context.Datas.ToList()
            };
            return View(homevM);
        }
    }
}

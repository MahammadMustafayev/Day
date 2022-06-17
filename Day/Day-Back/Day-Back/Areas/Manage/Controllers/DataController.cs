using Day_Back.DAL;
using Day_Back.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Day_Back.Areas.Manage.Controllers
{
    [Area("Manage")]
    public class DataController : Controller
    {
        private readonly AppDbContext _context;

        public DataController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View(_context.Datas.ToList());
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost,ValidateAntiForgeryToken]
        public IActionResult Create(Datas datas)
        {
            if (datas == null) return NotFound();
            _context.Datas.Add(datas);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));

        }
        public IActionResult Edit(int? id)
        {
            Datas datas = _context.Datas.FirstOrDefault(x => x.Id == id);
            if (datas == null) return NotFound();
            return View(datas);

        }
        [HttpPost,ValidateAntiForgeryToken]
        public IActionResult Edit(Datas datas)
        {
            Datas exstdata = _context.Datas.FirstOrDefault(x => x.Id == datas.Id);
            if (exstdata == null) return NotFound();
            exstdata.DataName = datas.DataName;
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Delete(int? id)
        {
            Datas datas = _context.Datas.Find(id);
            _context.Datas.Remove(datas);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}

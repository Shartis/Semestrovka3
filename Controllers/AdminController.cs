using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL.Models;
using DAL;
using DAL.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace Semestrovka4.Controllers
{

    [Authorize]
    public class AdminController : Controller
    {
        public readonly ApplicationContext _context;

        public AdminController(ApplicationContext appContext)
        {
            _context = appContext;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddTag(TagModel tag)
        {
            if (ModelState.IsValid)
            {
                var newtag = _context.Tags.FirstOrDefault(t => t.Name == tag.Name);
                if (newtag == null)
                {
                    _context.Tags.Add(new Tag()
                    {
                        Name = tag.Name
                    });
                    _context.SaveChanges();
                }
                return RedirectToAction("Index", "Admin");
            }
            return View(tag);
        }

        public IActionResult AddTag()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddArticle(DAL.Models.Article article)
        {
            return View();
        }

        public IActionResult AddArticle()
        {
            return View();
        }

        
    }
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using BLL.Models;
using DAL;
using DAL.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Semestrovka4.Controllers
{

    [Authorize]
    public class AdminController : Controller
    {
        public readonly ApplicationContext _context;
        private IWebHostEnvironment _appEnvironment;
        public AdminController(ApplicationContext appContext, IWebHostEnvironment appEnvironment)
        {
            _context = appContext;
            _appEnvironment = appEnvironment;
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
        public async Task<IActionResult> AddArticle(ArticleModel model)
        {

            if (model.Image != null)
            {
                // путь к папке Files
                string path = "/images/" + model.Image.FileName;
                // сохраняем файл в папку Files в каталоге wwwroot
                using (var fileStream = new FileStream(_appEnvironment.WebRootPath + path, FileMode.Create))
                {
                    await model.Image.CopyToAsync(fileStream);
                }

                var article = new Article()
                {
                    AuthorName = User.Identity.Name,
                    Content = model.Content,
                    DatePublic = DateTime.Now,
                    TagID = Convert.ToInt32(model.Tag),
                    Image = path,
                };
                _context.Articles.Add(article);
                await _context.SaveChangesAsync();

            }
            return RedirectToAction("Articles", "Article");
        }

        public IActionResult AddArticle()
        {
            var tags = _context.Tags.Select(t => new SelectListItem(t.Name, t.Id.ToString())).AsEnumerable();
            return View(new ArticleModel()
            {
                Tags = tags,
            });
        }


    }

}

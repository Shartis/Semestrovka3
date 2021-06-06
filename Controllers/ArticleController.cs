using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL;
using Microsoft.AspNetCore.Mvc;

namespace Semestrovka4.Controllers
{
    public class ArticleController : Controller
    {
        private readonly ApplicationContext _context;

        public ArticleController(ApplicationContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult Articles()
        {
            var tags = _context.Tags.AsEnumerable();
            var articles = _context.Articles.AsEnumerable();
            var model = new BLL.Models.ArticlesModel()
            {
                Tags = tags,
                Article = articles,
            };
            return View(model);

        }
        [HttpGet]
        public IActionResult Article()
        {
            return View();

        }
        public IActionResult GetPartialArticles(int tagId)
        {
            var model = _context.Articles.Where(a => a.TagID == tagId).AsEnumerable();
            return PartialView("ArticlePartialView", model);
        }
    }
}

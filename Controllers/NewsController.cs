using Microsoft.AspNetCore.Mvc;
using Semestrovka4.Data;
using Semestrovka4.Infrostructure;
using Semestrovka4.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Semestrovka4.Controllers
{
    public class ArticlesController : Controller
    {
        private readonly ApplicationContext _dbContext;
        private readonly GetArticleImage _getArticleImage;

        public SArticleController(ApplicationContext dbContext, GetArticleImage getArticleImage)
        {
            _dbContext = dbContext;
            _getArticleImage = getArticleImage;
        }

        [Route("~/Article")]
        public IActionResult Article()
        {
            var article = _dbContext.Article.Where(p => p.Category == "Article").ToList();
            var model = new Article()
            {
                Article = article
            };

            return View("Article", model);
        }

        [HttpGet("~/{Id}/image")]
        public IActionResult GetImage(int articleId)
        {
            var data = _getArticleImage.GetImage(articleId);
            return new FileStreamResult(new MemoryStream(data), "image/jpg");
        }        
    }
}

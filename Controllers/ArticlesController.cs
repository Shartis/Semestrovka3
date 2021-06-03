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

        public ArticlesController(ApplicationContext dbContext, GetArticleImage getArticleImage)
        {
            _dbContext = dbContext;
            _getArticleImage = getArticleImage;
        }

        [Route("~/Article")]
        public IActionResult Articles()
        {
            var articles = _dbContext.Articles.Where(p => p.Category == "Article").ToList();
            var model = new ArticleViewModel()
            {
                Articles = articles
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

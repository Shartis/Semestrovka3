using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
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
    [Authorize(Roles = "admin")]
    public class AdminPanelController : Controller
    {
        private readonly CommandService _commandService;
        private readonly ApplicationContext _dbContext;
        private readonly IWebHostEnvironment _appEnvironment;

        public AdminPanelController(CommandService commandService, ApplicationContext dbContext,
            IWebHostEnvironment appEnvironment)
        {
            _commandService = commandService;
            _dbContext = dbContext;
            _appEnvironment = appEnvironment;
        }

        public IActionResult Index()
        {
            ArticleViewModel model = new ArticleViewModel()
            {
               Articles = _dbContext.Articles.ToList()
            };
            return View("AdminPage", model);
        }

        public async Task<IActionResult> Article(string authorName, string content, string category, IFormFile image)
        {
            var ms = new MemoryStream();
            await image.CopyToAsync(ms);
            _dbContext.Article.Add(new Article()
            {
                AuthorName = authorName,
                Content = content,
                Category = category,
                Image = ms.ToArray()
            });
            _dbContext.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult DeletePost(int postId)
        {
            var post = _dbContext.Article.FirstOrDefault(p => p.Id == postId);
            if (post != null)
            {
                _dbContext.Article.Remove(post);
                _dbContext.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}

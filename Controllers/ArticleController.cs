using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Semestrovka4.Controllers
{
    public class ArticleController : Controller
    {
        [HttpGet]
        public IActionResult SignIn()
        {
            return View("SignIn");

        }
    }
}

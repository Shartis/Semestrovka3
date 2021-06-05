using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BLL.Models;
using BLL.Services.Interfaces;
using BLL.Services.Implementations;

namespace Semestrovka4.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountService _accountService;
        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Registration()
        {
            return View();
        }

        [HttpPost]
        public async Task <IActionResult> Registration(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                 await _accountService.Register(model);
                return RedirectToAction("Index", "Profile");
            }
            return View(model);

        }
    }
}

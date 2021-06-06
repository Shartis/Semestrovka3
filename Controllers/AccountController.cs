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
        private readonly AuthenticationService _authenticationService;
        public AccountController(IAccountService accountService, AuthenticationService authenticationService)
        {
            _accountService = accountService;
            _authenticationService = authenticationService;
        }

        public IActionResult Registration()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Registration(RegisterModel model)
        {
            var user1 = User;
            if (ModelState.IsValid)
            {
                var user = await _accountService.FindByNameAsync(model.Name);
                if (user == null)
                {
                    await _accountService.RegisterAsync(model);
                    return RedirectToAction("LogIn", "Account");
                }
                ModelState.AddModelError("", "Пользователь существует");

            }
            return View(model);

        }

        public IActionResult LogIn()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> LogIn(LoginModel model)
        {
            var user1 = User;

            if (ModelState.IsValid)
            {
                var user = await _accountService.FindByNameAsync(model.Name);
                if (user != null)
                {
                    await _accountService.LogInAsync(model.Name, model.Password, model.RememberMe);
                    return RedirectToAction("Index", "Profile");
                }
                return RedirectToAction("Registration", "Account");
            }
            return View(model);

        }
        public async Task<IActionResult> LogOut()
        {
            await _accountService.LogOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}

﻿using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Semestrovka4.Data;
using Semestrovka4.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Semestrovka4.Infrostructure;

namespace Semestrovka4.Controllers
{
    [Authorize]
    public class ProfileController : Controller
    {
        private readonly ApplicationContext _dbContext;
        private readonly IWebHostEnvironment _appEnvironment;
        private readonly Infrostructure.AuthenticationService _authenticationService;

        public ProfileController(ILogger<ProfileController> logger, ApplicationContext dbContext,
            IWebHostEnvironment appEnvironment, Infrostructure.AuthenticationService authenticationService)
        {
            _dbContext = dbContext;
            _appEnvironment = appEnvironment;
            _authenticationService = authenticationService;
        }

        [Route("~/profile/{userId:int?}")]
        public IActionResult Profile(int userId)
        {
            if (userId == -1)
                if (User.Identity.IsAuthenticated)
                    userId = Int32.Parse(User.FindFirst("id").Value);
                else return RedirectToAction("Index", "Home");

            var user = _dbContext.Users.FirstOrDefault(u => u.Id == userId);
            if (user == null)
                return RedirectToAction("Index", "Home");

            var model = new UserViewModel()
            {
                Email = user.Email,
                Id = user.Id,
                Name = user.Name,
                Surname = user.Surname
            };

            return View(model);
        }

        [HttpGet]
        [Authorize]
        public IActionResult ProfileEdit()
        {
            int userId = Int32.Parse(User.FindFirst("id").Value);
            var user = _dbContext.Users.FirstOrDefault(u => u.Id == userId);
            if (user == null)
                return RedirectToAction("Index", "Home");

            var model = new UserViewModel()
            {
                Email = user.Email,
                Id = user.Id,
                Name = user.Name,
                Surname = user.Surname
            };

            return View(model);
        }

        [HttpPost("~/profile/uploadImage")]
        [Authorize]
        public async Task<IActionResult> UploadImage(IFormFile image)
        {
            int userId = Int32.Parse(User.FindFirst("id").Value);
            var user = _dbContext.Users.FirstOrDefault(u => u.Id == userId);
            var ms = new MemoryStream();
            await image.CopyToAsync(ms);
            user.Image = ms.ToArray();
            return Redirect("~/profile");
        }

        [HttpGet("~/profile/{userId}/image")]
        public IActionResult GetImage(int userId)
        {
            var user = _dbContext.Users.FirstOrDefault(u => u.Id == userId);
            if (user == null)
                return StatusCode(500);
            var data = user.Image;
            if (data == null)
                return BadRequest();

            return new FileStreamResult(new MemoryStream(data), "image/jpg");
        }

        [HttpPost]
        public async Task<IActionResult> ProfileEdit(UserViewModel data)
        {
            if (ModelState.IsValid)
            {
                var user = _dbContext.Users.FirstOrDefault(u => u.Id == data.Id);
                if (user == null)
                    return RedirectToAction("Index", "Home");

                user.Name = data.Name;
                user.Surname = data.Surname;

                _dbContext.SaveChanges();

                await _authenticationService.ReAuthenticate(user.Name, false);

                return Redirect("~/profile");
            }

            return RedirectToAction("ProfileEdit");
        }

        [Authorize]
        [HttpPost]
        public IActionResult ProfileEditPassword(PasswordChangeModel data)
        {
            int userId = Int32.Parse(User.FindFirst("id").Value);
            var user = _dbContext.Users.FirstOrDefault(u => u.Id == userId);
            if (user == null)
                return RedirectToAction("Login", "Account");

            if (user.HashedPassword != AccountController.HashPassword(data.OldPassword))
            {
                TempData["PasswordNotMatch"] = "Старый пароль не совпадает.";
                ModelState.AddModelError("", "Старый пароль не совпадает.");
            }

            if (!ModelState.IsValid)
                return RedirectToAction("ProfileEdit");

            user.HashedPassword = AccountController.HashPassword(data.NewPassword);
            _dbContext.SaveChanges();
            TempData["PasswordChangeSuccess"] = true;

            return RedirectToAction("ProfileEdit");
        }

    }
}

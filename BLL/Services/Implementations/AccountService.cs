using BLL.Models;
using BLL.Services.Interfaces;
using DAL;
using DAL.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.Implementations
{
    public class AccountService : IAccountService
    {
        private readonly ApplicationContext _Context;

        public readonly UserManager<User> _userManager;
        public readonly SignInManager<User> _signInManager;

        public AccountService(ApplicationContext context, UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _Context = context;
            _signInManager = signInManager;
            _userManager = userManager;
        }

        public async Task<User> FindByNameAsync(string name)
        {
            var user = await _userManager.FindByNameAsync(name);
            return user;
        }
        public async Task LogInAsync(string name, string password, bool rememberMe)
        {
            var res = await _signInManager.PasswordSignInAsync(name, password, rememberMe, false);
        }
        public async Task LogOutAsync()
        {
            await _signInManager.SignOutAsync();
        }

        public async Task RegisterAsync(RegisterModel model)
        {
            User user = await FindByNameAsync(model.Name);
            if (user == null)
            {
                var res = await _userManager.CreateAsync(new User()
                {
                    UserName = model.Name,
                    Email = model.Email,
                }, model.Password);
            }

        }

    }
}

using BLL.Models;
using BLL.Services.Interfaces;
using DAL;
using DAL.Models;
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
        private readonly IPasswordHasher _passwordHasher;
        private readonly AuthenticationService _authenticationService;
        public AccountService(ApplicationContext context, IPasswordHasher passwordHasher, AuthenticationService authenticationService)
        {
            _Context = context;
            _passwordHasher = passwordHasher;
            _authenticationService = authenticationService;
        }

        public async Task<User> FindByEmailAsync(string email)
        {
            var user = await _Context.Users.FirstOrDefaultAsync(X => X.Email == email);
            return user;
        }
        public async Task<User> FindByEmailAndPasswordAsync(string email, string password)
        {
            var user = await _Context.Users.FirstOrDefaultAsync(X => X.Email == email && X.HashedPassword == _passwordHasher.Hash(password));
            return user;
        }
        public async Task LogInAsync(User user, bool rememberMe)
        {
            await _authenticationService.Authenticate(user, rememberMe);
        }
        public async Task LogOutAsync()
        {
            await _authenticationService.Logout();
        }

        public async Task RegisterAsync(RegisterModel model)
        {
            User user = await _Context.Users.FirstOrDefaultAsync(u => u.Email == model.Email);
            if (user == null)
            {
                user = new User
                {
                    Email = model.Email,
                    Name = model.Name,
                    HashedPassword = _passwordHasher.Hash(model.Password),
                    Role = "user",
                };
                await _Context.AddAsync(user);
                await _Context.SaveChangesAsync();

            }

        }


    }
}

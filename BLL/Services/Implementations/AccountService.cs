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
        public AccountService(ApplicationContext context, IPasswordHasher passwordHasher)
        {
            _Context = context;
            _passwordHasher = passwordHasher;
        }
        public Task LogIn(RegisterModel model)
        {
            throw new NotImplementedException();
        }

        public async Task Register(RegisterModel model)
        {
            User user = await _Context.Users.FirstOrDefaultAsync(u => u.Email == model.Email);
            if (user == null)
            {
                user = new User
                {
                    Email = model.Email,
                    Name = model.Name,
                    HashedPassword = _passwordHasher.Hash(model.Password),
                };
            }
        }
    }
}

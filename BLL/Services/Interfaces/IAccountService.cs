using BLL.Models;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.Interfaces
{
    public interface IAccountService
    {
        public Task RegisterAsync(RegisterModel model);
        public Task LogInAsync(string email, string password, bool rememberMe);
        public Task LogOutAsync();
        public Task<User> FindByNameAsync(string name);
    }
}

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
        public Task Register(RegisterModel model);
        public Task LogIn(RegisterModel model);

        public Task<User> FindByEmail(string email);
    }


}

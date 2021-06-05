using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BLL.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Не указан Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Не указан пароль")]
        public string Password { get; set; }

        public string RememberMe { get; set; }
    }
}

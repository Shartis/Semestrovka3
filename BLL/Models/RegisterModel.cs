using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BLL.Models
{
    public class RegisterModel
    {
        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "Не указан Email")]
        public string Email { get; set; }


        [Required(ErrorMessage = "Не указано Имя")]
        public string Name { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Не указан пароль")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Пароль не совпадает")]
        public string ConfirmPassword { get; set; }
    }
}

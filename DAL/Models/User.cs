using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class User:IdentityUser<int>
    {        
        public int Id { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string HashedPassword { get; set; } 
        public string Image;
    }
}

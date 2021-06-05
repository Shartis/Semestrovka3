using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Semestrovka4.Models
{
    public class User:IdentityUser
    {        
        public int Id { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string HashedPassword { get; set; } 
        public byte[] Image;
        public string Role { get; set; }
    }
}

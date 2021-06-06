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
        public override int Id { get; set; }
        public string Image { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BLL.Models
{
    public class TagModel
    {
        [Required]
        public string Name { get; set; }      
        
    }
}

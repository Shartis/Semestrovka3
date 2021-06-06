using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BLL.Models
{
    public class ArticleModel
    {

        [Required]
        public string Content { get; set; }
        [Required]
        public IFormFile Image { get; set; }
        [Required]
        public string Tag { get; set; }

        public IEnumerable<SelectListItem> Tags { get; set; }

    }
}

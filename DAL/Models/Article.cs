using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Article
    {              
        public int Id { get; set; }
        public string AuthorName { get; set; }
        public string Content { get; set; }
        public string Image { get; set; }
        public int TagID { get; set; }
        public Tag Tag { get; set; }
        public DateTime DatePublic { get; set; }
    }
}

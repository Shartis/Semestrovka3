using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Semestrovka4.Models
{
    public class Article
    {              
        public int Id { get; set; }
        public string AuthorName { get; set; }
        public string Content { get; set; }
        public string Category { get; set; }
        public byte[] Image { get; set; }
        public string TagID { get; set; }
        public Tag Tag { get; set; }
        public string ID { get; set; }
        public DateTime DatePublic { get; set; }
    }
}

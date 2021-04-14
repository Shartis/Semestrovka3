using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Semestrovka4.Models
{
    public class Article
    {
        public string UserID { get; set; }
        public User User { get; set; }
        public string Name { get; set; }
        public string Content { get; set; }
        public string TagID { get; set; }
        public Tag Tag { get; set; }
        public string ID { get; set; }
        public DateTime DatePublic {get;set;}
    }
}

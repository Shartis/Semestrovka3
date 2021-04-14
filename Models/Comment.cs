using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Semestrovka4.Models
{
    public class Comment
    {
        public string ID { get; set; }
        public string UserID { get; set; }
        public User User { get; set; }
        public string Content { get; set; }
        public string ArticleID { get; set; }
        public Article Article { get; set; }
        public DateTime DatePublic { get; set; }
    }
}

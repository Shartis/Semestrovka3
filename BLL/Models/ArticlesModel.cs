using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BLL.Models
{
    public class ArticlesModel
    {
        public IEnumerable<Tag> Tags { get; set; }
        public IEnumerable<Article> Article { get; set; }
    }
}

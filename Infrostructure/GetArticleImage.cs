using Semestrovka4.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Semestrovka4.Infrostructure
{
    public class GetArticleImage
    {
        private readonly ApplicationContext _dbContext;

        public GetArticleImage(ApplicationContext dbContext)
        {
            _dbContext = dbContext;
        }

        public byte[] GetImage(int articleId)
        {
            var post = _dbContext.Article.FirstOrDefault(p => p.Id == articleId);
            if (post == null)
                return null;
            var data = post.Image;
            if (data == null)
                return null;
            return data;
        }
    }
}
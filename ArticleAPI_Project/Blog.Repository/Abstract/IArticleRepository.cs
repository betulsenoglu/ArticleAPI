using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Blog.Database.Abstract;
using Blog.Domain.Entities.Models.Article;

namespace Blog.Repository.Abstract
{
    public interface IArticleRepository : IGenericRepository<Article>
    {
        Task<IList<Article>> SearchInArticlesAsync(string text);
    }
}
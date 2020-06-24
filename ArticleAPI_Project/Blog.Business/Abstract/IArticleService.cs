using System.Collections.Generic;
using System.Threading.Tasks;
using Blog.Domain.Definitions.Responses;
using Blog.Domain.Entities.Models.Article;

namespace Blog.Business.Abstract
{
    public interface IArticleService
    {
        Task<ServiceResponse<List<Article>>> GetAllAsync();
        ServiceResponse<Article> GetByIdAsync(string id);
        Task<ServiceResponse<IList<Article>>> SearchInArticles(string keyword);
        Task<ServiceResponse<Article>> CreateAsync(Article model);
        Task<ServiceResponse<Article>> UpdateAsync(string id, Article model);
        Task<ServiceResponse<bool>> DeleteAsync(string id);
        ServiceResponse<List<Article>> GetAll();
        ServiceResponse<Article> GetById(string id);
        ServiceResponse<bool> Update(string id, Article model);
        ServiceResponse<bool> Delete(string id);
    }
}
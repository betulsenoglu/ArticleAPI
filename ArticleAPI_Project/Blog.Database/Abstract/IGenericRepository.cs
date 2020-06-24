using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Database.Abstract
{
    public interface IGenericRepository<T> where T : class
    {
        IQueryable<T> Query();
        Task<bool> CreateAsync(T model);
        Task<T> UpdateAsync(string id, T model);
        Task<List<T>> GetAllAsync();
        Task<T> GetByIdAsync(string id);
        Task<bool> DeleteAsync(string id);
        bool Delete(string id);
        T GetById(string id);
        bool Update(string id, T model);
        List<T> GetAll();
    }
}
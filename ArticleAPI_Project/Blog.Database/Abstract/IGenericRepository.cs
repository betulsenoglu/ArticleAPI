using System.Collections.Generic;
using System.Threading.Tasks;

namespace Blog.Database.Abstract
{
    public interface IGenericRepository<T> where T:class
    {
        Task<bool> CreateAsync(T model);
        Task<T> UpdateAsync(string id, T model);
        Task<List<T>> GetAllAsync();
        Task<T> GetByIdAsync(string id);
        Task<bool> DeleteAsync(string id);
        void Delete(string id);
        T GetById(string id);
        void Update(string id, T model);
        List<T> GetAll();
        
    }
}
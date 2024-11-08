using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlazorApp1.Interface
{
    public interface IService<TEntity>
    {
        Task<List<TEntity>> GetAllAsync();
        Task<TEntity> GetByIdAsync(int id);
        Task<TEntity> GetByStringAsync(string value);
        Task AddAsync(TEntity entity);
        Task UpdateAsync(TEntity entity);
        Task DeleteAsync(int id);
    }
}

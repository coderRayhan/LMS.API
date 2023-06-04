using LMS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Application.Interfaces.Repositories
{
    public interface IGenericRepositoryAsync<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<IReadOnlyList<T>> GetPagedRangeAsync(int page, int pageSize);
        Task<T> GetByIdAsync(int id);
        Task<T> AddAsync (T entity);
        Task<T> AddOrUpdateAsync (T entity);
        Task AddRangeAsync (List<T> entities);
        Task AddOrUpdateRangeAsync(List<T> entities);
        Task UpdateAsync (T entity);
        Task DeleteAsync (T entity);
    }
}

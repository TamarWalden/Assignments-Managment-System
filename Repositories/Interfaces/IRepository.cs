using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Interfaces
{
    public interface IRepository<T>
    {
        Task<T> GetByIdAsync(int id);
        Task<T> UpdateAsync(T entity);
        Task<List<T>> GetAllAsync();
        Task<List<T>> GetAllByPagingAsync(GetDataParameters getDataParameters);
        Task<T> AddAsync(T entity);
        Task DeleteAsync(int id);
    }
}


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T> GetAsync(int? id);
        Task<TResult> GetAsync<TResult>(int? id);
        Task<List<T>> GetAllAsync();
        Task<List<TResult>> GetAllAsync<TResult>();
        Task<T> AddAsynch(T entity);
        Task<TResult> AddAsynch<Tsource, TResult>(Tsource tsource);
        Task DeleteAsync(int? id);
        Task UpdateAsync(int? id,T entity);
        Task<bool> Exists(int id);

    }
}

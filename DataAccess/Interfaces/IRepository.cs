using Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Interfaces
{
    public interface IRepository<T> where T : class, IEntity
    {
        Task<List<T>> GetAllAsync();
        Task<List<T>> GetAllAsync(Expression<Func<T,bool>> expression, List<string> includedProperties);
        IQueryable<T> GetAll(Expression<Func<T,bool>> expression, List<string> includedProperties);
        Task<bool> GetAllAsync(Expression<Func<T,bool>> expression);
        Task<T> GetAsync(int id);
        Task<T> GetAsync(Expression<Func<T, bool>> expression,List<string> includedProperties);
        Task<bool> CreateAsync(T entity);
        Task<bool> CreateAsync(IEnumerable<T> entities);
        Task<bool> CreateAsync(params T[] entities);
        Task<bool> CreateAsync(params object[] entities);
        Task<bool> UpdateAsync(T entity);
        Task<bool> UpdateAsync(IEnumerable<T> entities);
        Task<bool> UpdateAsync(params T[] entities);
        Task<bool> UpdateAsync(params object[] entities);
        Task<bool> DeleteAsync(T entity);
        Task<bool> DeleteAsync(IEnumerable<T> entities);
    }
}

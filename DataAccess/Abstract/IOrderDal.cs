using Core.Repository;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IOrderDal : IRepository<Order>
    {
        Task<List<Order>> GetOrdersByCountAsync(int skipCount, int takeCount);

        Task<List<Order>> GetOrdersByCountAsync(string userId, int skipCount, int takeCount);

        Task<List<Order>> GetOrdersByUserAsync(string userId);

        Task<Order> GetOrderWithStatus(int id);

        Task<Order> GetOrderByFilter(Expression<Func<Order, bool>> expression);

        Task<List<Order>> GetOrdersByFilter(Expression<Func<Order, bool>> expression, int skipCount, int takeCount); 

        Task<List<Order>> GetOrdersByFilter(Expression<Func<Order, bool>> expression); 
    }
}

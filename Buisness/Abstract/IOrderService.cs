using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Buisness.Abstract
{
    public interface IOrderService
    {
        Task<Order> GetOrderAsync(int id);

        Task<Order> GetOrderAsync(Expression<Func<Order, bool>> expression);

        Task<Order> GetOrderWithIncludeAsync(int id);

        Task<List<Order>> GetAllOrdersAsync();

        Task<List<Order>> GetAllOrdersAsync(int skipCount, int takeCount);

        Task<List<Order>> GetAllOrdersAsync(string userId ,int skipCount, int takeCount);

        Task<List<Order>> GetAllOrdersAsync(Expression<Func<Order, bool>> expression ,int skipCount, int takeCount);

        Task<List<Order>> GetAllOrdersAsync(Expression<Func<Order, bool>> expression);

        Task<List<Order>> GetAllOrdersAsync(string userId);

        Task<bool> AddAsync(Order order);

        Task<bool> UpdateAsync(Order order);

        Task<bool> DeleteAsync(int id);
    }
}

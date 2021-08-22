using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Buisness.Abstract
{
    public interface IOrderService
    {
        Task<Order> GetOrderAsync(int id);

        Task<List<Order>> GetAllOrdersAsync();

        Task<List<Order>> GetAllOrdersAsync(int skipCount, int takeCount);

        Task<bool> AddAsync(Order order);

        Task<bool> UpdateAsync(Order order);

        Task<bool> DeleteAsync(int id);
    }
}

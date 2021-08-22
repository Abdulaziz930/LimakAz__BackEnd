using Buisness.Abstract;
using DataAccess.Abstract;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Buisness.Concret
{
    public class OrderManager : IOrderService
    {
        private readonly IOrderDal _orderDal;

        public OrderManager(IOrderDal orderDal)
        {
            _orderDal = orderDal;
        }

        public async Task<bool> AddAsync(Order order)
        {
            await _orderDal.AddAsync(order);

            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            await _orderDal.DeleteAsync(new Order { Id = id });

            return true;
        }

        public async Task<List<Order>> GetAllOrdersAsync()
        {
            return await _orderDal.GetAllAsync();
        }

        public async Task<List<Order>> GetAllOrdersAsync(int skipCount, int takeCount)
        {
            return await _orderDal.GetOrdersByCountAsync(skipCount, takeCount);
        }

        public async Task<Order> GetOrderAsync(int id)
        {
            return await _orderDal.GetAsync(x => x.Id == id);
        }

        public async Task<bool> UpdateAsync(Order order)
        {
            await _orderDal.UpdateAsync(order);

            return true;
        }
    }
}

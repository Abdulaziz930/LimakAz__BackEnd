using Buisness.Abstract;
using DataAccess.Abstract;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Buisness.Concret
{
    public class OrderContentManager : IOrderContentService
    {
        private readonly IOrderContentDal _orderContentDal;

        public OrderContentManager(IOrderContentDal orderContentDal)
        {
            _orderContentDal = orderContentDal;
        }

        public async Task<bool> AddAsync(OrderContent orderContent)
        {
            await _orderContentDal.AddAsync(orderContent);

            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            await _orderContentDal.DeleteAsync(new OrderContent { Id = id });

            return true;
        }

        public async Task<List<OrderContent>> GetAllOrderContentsAsync()
        {
            return await _orderContentDal.GetAllAsync();
        }

        public async Task<OrderContent> GetOrderContentAsync(int id)
        {
            return await _orderContentDal.GetAsync(x => x.Id == id);
        }

        public async Task<OrderContent> GetOrderContentAsync(string languageCode)
        {
            return await _orderContentDal.GetOrderContentAsync(languageCode);
        }

        public async Task<bool> UpdateAsync(OrderContent orderContent)
        {
            await _orderContentDal.UpdateAsync(orderContent);

            return true;
        }
    }
}

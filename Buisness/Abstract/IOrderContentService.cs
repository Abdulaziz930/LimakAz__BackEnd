using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Buisness.Abstract
{
    public interface IOrderContentService
    {
        Task<OrderContent> GetOrderContentAsync(int id);

        Task<OrderContent> GetOrderContentAsync(string languageCode);

        Task<List<OrderContent>> GetAllOrderContentsAsync();

        Task<bool> AddAsync(OrderContent orderContent);

        Task<bool> UpdateAsync(OrderContent orderContent);

        Task<bool> DeleteAsync(int id);
    }
}

using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Buisness.Abstract
{
    public interface IShopService
    {
        Task<Shop> GetShopAsync(int id);

        Task<List<Shop>> GetAllShopsAsync();

        Task<List<Shop>> GetAllShopsAsync(int skipCount, int takeCount);

        Task<List<Shop>> GetAllShopsAsync(int id, int skipCount, int takeCount);

        Task<List<Shop>> GetAllShopsAsync(int id);

        Task<List<Shop>> GetAllRecommendedShopsAsync();

        Task<bool> AddAsync(Shop shop);

        Task<bool> UpdateAsync(Shop shop);

        Task<bool> DeleteAsync(int id);
    }
}

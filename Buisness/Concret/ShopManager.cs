using Buisness.Abstract;
using DataAccess.Abstract;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Buisness.Concret
{
    public class ShopManager : IShopService
    {
        private readonly IShopDal _shopDal;

        public ShopManager(IShopDal shopDal)
        {
            _shopDal = shopDal;
        }

        public async Task<bool> AddAsync(Shop shop)
        {
            await _shopDal.AddAsync(shop);

            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            await _shopDal.DeleteAsync(new Shop { Id = id });

            return true;
        }

        public async Task<List<Shop>> GetAllShopsAsync()
        {
            return await _shopDal.GetAllAsync(x => x.IsDeleted == false);
        }

        public async Task<List<Shop>> GetAllShopsAsync(int skipCount, int takeCount)
        {
            return await _shopDal.GetShopsByCountAsync(skipCount, takeCount);
        }

        public async Task<List<Shop>> GetAllShopsAsync(int id, int skipCount, int takeCount)
        {
            return await _shopDal.GetShopsByCountAsync(id, skipCount, takeCount);
        }

        public async Task<List<Shop>> GetAllRecommendedShopsAsync()
        {
            return await _shopDal.GetRecommendedShopsAsync();
        }

        public async Task<Shop> GetShopAsync(int id)
        {
            return await _shopDal.GetShopWithInclude(id);
        }

        public async Task<bool> UpdateAsync(Shop shop)
        {
            await _shopDal.UpdateAsync(shop);

            return true;
        }
    }
}

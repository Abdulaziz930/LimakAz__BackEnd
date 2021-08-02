using Buisness.Abstract;
using DataAccess.Abstract;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Buisness.Concret
{
    public class ShopContentManager : IShopContentService
    {
        private readonly IShopContentDal _shopContentDal;

        public ShopContentManager(IShopContentDal shopContentDal)
        {
            _shopContentDal = shopContentDal;
        }

        public async Task<bool> AddAsync(ShopContent shopContent)
        {
            await _shopContentDal.AddAsync(shopContent);

            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            await _shopContentDal.DeleteAsync(new ShopContent { Id = id });

            return true;
        }

        public async Task<List<ShopContent>> GetAllShopContentsAsync()
        {
            return await _shopContentDal.GetAllAsync(x => x.IsDeleted == false);
        }

        public async Task<List<ShopContent>> GetAllShopContentsAsync(int skipCount, int takeCount)
        {
            return await _shopContentDal.GetShopContentsByCountAsync(skipCount, takeCount);
        }

        public async Task<ShopContent> GetShopContentAsync(int id)
        {
            return await _shopContentDal.GetAsync(x => x.Id == id && x.IsDeleted == false);
        }

        public async Task<ShopContent> GetShopContentAsync(string languageCode)
        {
            return await _shopContentDal.GetShopContentAsync(languageCode);
        }

        public async Task<bool> UpdateAsync(ShopContent shopContent)
        {
            await _shopContentDal.UpdateAsync(shopContent);

            return true;
        }
    }
}

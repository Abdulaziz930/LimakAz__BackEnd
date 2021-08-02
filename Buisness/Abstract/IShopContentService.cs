using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Buisness.Abstract
{
    public interface IShopContentService
    {
        Task<ShopContent> GetShopContentAsync(int id);

        Task<ShopContent> GetShopContentAsync(string languageCode);

        Task<List<ShopContent>> GetAllShopContentsAsync();

        Task<List<ShopContent>> GetAllShopContentsAsync(int skipCount, int takeCount);

        Task<bool> AddAsync(ShopContent shopContent);

        Task<bool> UpdateAsync(ShopContent shopContent);

        Task<bool> DeleteAsync(int id);
    }
}

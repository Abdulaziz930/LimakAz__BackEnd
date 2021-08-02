using Core.Repository;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IShopContentDal : IRepository<ShopContent>
    {
        Task<ShopContent> GetShopContentAsync(string languageCode);

        Task<List<ShopContent>> GetShopContentsByCountAsync(int skipCount, int takeCount);
    }
}

using Core.Repository;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IShopDal : IRepository<Shop>
    {
        Task<Shop> GetShopWithInclude(int id);

        Task<List<Shop>> GetShopsByCountAsync(int skipCount, int takeCount);

        Task<List<Shop>> GetShopsByCountAsync(int id, int skipCount, int takeCount);

        Task<List<Shop>> GetRecommendedShopsAsync();
    }
}

using Core.Repository.EFRepository;
using DataAccess.Abstract;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concret
{
    public class EFShopDal : EFRepositoryBase<Shop, AppDbContext>, IShopDal
    {
        public async Task<List<Shop>> GetRecommendedShopsAsync()
        {
            await using var context = new AppDbContext();
            return await context.Shops.Where(x => x.IsRecommended == true && x.IsDeleted == false).ToListAsync();
        }

        public async Task<List<Shop>> GetShopsByCountAsync(int skipCount, int takeCount)
        {
            await using var context = new AppDbContext();
            return await context.Shops.Include(x => x.ShopCountries).ThenInclude(x => x.Country)
                .Where(x => x.IsDeleted == false && x.ShopCountries.Any(x => x.Country.IsDeleted == false))
                .OrderByDescending(x => x.LastModificationDate).Skip(skipCount).Take(takeCount).ToListAsync();
        }

        public async Task<List<Shop>> GetShopsByCountAsync(int id, int skipCount, int takeCount)
        {
            await using var context = new AppDbContext();
            return await context.Shops.Include(x => x.ShopCountries).ThenInclude(x => x.Country)
                .Where(x => x.IsDeleted == false && x.ShopCountries.Any(x => x.CountryId == id && x.Country.IsDeleted == false))
                .OrderByDescending(x => x.LastModificationDate).Skip(skipCount).Take(takeCount).ToListAsync();
        }

        public async Task<Shop> GetShopWithInclude(int id)
        {
            await using var context = new AppDbContext();
            return await context.Shops.Include(x => x.ShopCountries).ThenInclude(x => x.Country)
                .FirstOrDefaultAsync(x => x.Id == id && x.IsDeleted == false && x.ShopCountries.Any(x => x.Country.IsDeleted == false));
        }
    }
}

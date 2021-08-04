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
    public class EFAdvertisementDal : EFRepositoryBase<Advertisement, AppDbContext>, IAdvertisementDal
    {
        public async Task<List<Advertisement>> GetAllMultiLanguageAdvertisementAsync(string languageCode)
        {
            await using var context = new AppDbContext();
            return await context.Advertisements.Include(x => x.Language)
                .Where(x => x.Language.Code == languageCode && x.IsDeleted == false).ToListAsync();
        }

        public async Task<Advertisement> GetMultiLanguageAdvertisementAsync(int id, string languageCode)
        {
            await using var context = new AppDbContext();
            return await context.Advertisements.Include(x => x.Language).Include(x => x.AdvertisementDetail)
                .FirstOrDefaultAsync(x => x.Key == id && x.Language.Code == languageCode && x.IsDeleted == false 
                                    && x.AdvertisementDetail.Language.Code == languageCode
                                    && x.AdvertisementDetail.IsDeleted == false
                                    && x.Language.IsDeleted == false);
        }

        public async Task<List<Advertisement>> GetAdvertisementByCountAsync(int skipCount, int takeCount)
        {
            await using var context = new AppDbContext();
            return await context.Advertisements.Where(x => x.IsDeleted == false)
                .OrderByDescending(x => x.LastModificationDate).Skip(skipCount).Take(takeCount).ToListAsync();
        }

        public async Task<List<Advertisement>> GetAdvertisementByCountAsync(int takeCount,string languageCode)
        {
            await using var context = new AppDbContext();
            return await context.Advertisements.Include(x => x.Language).Include(x => x.AdvertisementDetail)
                .Where(x => x.Language.Code == languageCode && x.IsDeleted == false 
                        && x.AdvertisementDetail.IsDeleted == false && x.Language.IsDeleted == false)
                .OrderByDescending(x => x.LastModificationDate).Take(takeCount).ToListAsync();
        }

        public async Task<bool> AddRangeAsync(Advertisement advertisement, AdvertisementDetail advertisementDetail)
        {
            await using (var context = new AppDbContext())
            {
                await using var dbContextTransaction = await context.Database.BeginTransactionAsync();
                try
                {
                    await context.AddRangeAsync(advertisement,advertisementDetail);
                    await context.SaveChangesAsync();
                    await dbContextTransaction.CommitAsync();

                    return true;
                }
                catch (Exception)
                {
                    await dbContextTransaction.RollbackAsync();
                    throw;
                }
            }
        }

        public async Task<Advertisement> GetAdvertisementWithInclude(int id)
        {
            await using var context = new AppDbContext();
            return await context.Advertisements.Include(x => x.AdvertisementDetail)
                .FirstOrDefaultAsync(x => x.Id == id && x.IsDeleted == false && x.AdvertisementDetail.IsDeleted == false);
        }

        public async Task<Advertisement> GetAdvertisementWithIncludes(int id)
        {
            await using var context = new AppDbContext();
            return await context.Advertisements.Include(x => x.AdvertisementDetail).Include(x => x.Language)
                .FirstOrDefaultAsync(x => x.Id == id && x.IsDeleted == false 
                                    && x.AdvertisementDetail.IsDeleted == false && x.Language.IsDeleted == false);
        }
    }
}

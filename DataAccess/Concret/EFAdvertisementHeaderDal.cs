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
    public class EFAdvertisementHeaderDal : EFRepositoryBase<AdvertisementHeader, AppDbContext>, IAdvertisementHeaderDal
    {

        public EFAdvertisementHeaderDal(AppDbContext context) : base(context)
        {
        }

        public async Task<AdvertisementHeader> GetAdvertisementHeaderAsync(string languageCode)
        {
            return await Context.AdvertisementHeaders.Include(x => x.Language)
                .FirstOrDefaultAsync(x => x.IsDeleted == false && x.Language.IsDeleted == false && x.Language.Code == languageCode);
        }

        public async Task<List<AdvertisementHeader>> GetAdvertisementHeadersByCountAsync(int skipCount, int takeCount)
        {
            return await Context.AdvertisementHeaders
                .Where(x => x.IsDeleted == false).OrderByDescending(x => x.Id)
                .Skip(skipCount).Take(takeCount).ToListAsync();
        }
    }
}

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
    public class EFAddressContentDal : EFRepositoryBase<AddressContent, AppDbContext>, IAddressContentDal
    {
        public async Task<List<Country>> GetAddressContentsAsync(string languageCode)
        {
            await using var context = new AppDbContext();
            return await context.Countries.Include(x => x.Language)
                .Include(x => x.AddressContents)
                .Where(x => x.IsDeleted == false 
                && x.Language.Code == languageCode 
                && x.Language.IsDeleted == false)
                .ToListAsync();
        }

        public async Task<List<AddressContent>> GetAddressContentsByCountAsync(int skipCount, int takeCount)
        {
            await using var context = new AppDbContext();
            return await context.AddressContents
                .OrderByDescending(x => x.Id)
                .Skip(skipCount).Take(takeCount).ToListAsync();
        }
    }
}

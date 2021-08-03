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
    public class EFCountryContentDal : EFRepositoryBase<CountryContent, AppDbContext>, ICountryContentDal
    {
        public async Task<CountryContent> GetCountryContentAsync(string languageCode)
        {
            await using var context = new AppDbContext();
            return await context.CountryContents.Include(x => x.Language)
                .FirstOrDefaultAsync(x => x.IsDeleted == false && x.Language.IsDeleted == false && x.Language.Code == languageCode);
        }

        public async Task<List<CountryContent>> GetCountryContentsByCountAsync(int skipCount, int takeCount)
        {
            await using var context = new AppDbContext();
            return await context.CountryContents
                .Where(x => x.IsDeleted == false).OrderByDescending(x => x.Id)
                .Skip(skipCount).Take(takeCount).ToListAsync();
        }
    }
}

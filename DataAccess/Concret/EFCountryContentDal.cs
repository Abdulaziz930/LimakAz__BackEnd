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
        public EFCountryContentDal(AppDbContext context) : base(context)
        {
        }

        public async Task<CountryContent> GetCountryContentAsync(string languageCode)
        {
            return await Context.CountryContents.Include(x => x.Language)
                .FirstOrDefaultAsync(x => x.IsDeleted == false && x.Language.IsDeleted == false && x.Language.Code == languageCode);
        }

        public async Task<List<CountryContent>> GetCountryContentsByCountAsync(int skipCount, int takeCount)
        {
            return await Context.CountryContents
                .Where(x => x.IsDeleted == false).OrderByDescending(x => x.Id)
                .Skip(skipCount).Take(takeCount).ToListAsync();
        }
    }
}

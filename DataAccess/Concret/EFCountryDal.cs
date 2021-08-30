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
    public class EFCountryDal : EFRepositoryBase<Country, AppDbContext>, ICountryDal
    {
        public EFCountryDal(AppDbContext context) : base(context)
        {
        }

        public async Task<List<Country>> GetAllMultiLanguageCountriesAsync(string languageCode)
        {
            return await Context.Countries.Include(x => x.Language)
                .Where(x => x.Language.Code == languageCode && x.Language.IsDeleted == false && x.IsDeleted == false).ToListAsync();
        }

        public async Task<List<Country>> GetCountriesByCountAsync(int skipCount, int takeCount)
        {
            return await Context.Countries.Where(x => x.IsDeleted == false)
                .OrderByDescending(x => x.Id).Skip(skipCount).Take(takeCount).ToListAsync();
        }

        public async Task<Country> GetCountryWithIncludeAsync(int id)
        {
            return await Context.Countries.Include(x => x.Language)
                .FirstOrDefaultAsync(x => x.Id == id && x.IsDeleted == false && x.Language.IsDeleted == false);
        }

        public async Task<Country> GetMultiLanguageCountryAsync(int id, string languageCode)
        {
            return await Context.Countries.Include(x => x.Language)
                .FirstOrDefaultAsync(x => x.Language.Code == languageCode && x.Language.IsDeleted == false && x.IsDeleted == false);
        }
    }
}

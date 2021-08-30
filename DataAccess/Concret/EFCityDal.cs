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
    public class EFCityDal : EFRepositoryBase<City, AppDbContext>, ICityDal
    {
        public EFCityDal(AppDbContext context) : base(context)
        {
        }

        public async Task<List<City>> GetAllMultiLanguageCitiesAsync(string languageCode)
        {
            return await Context.Cities.Include(x => x.Language)
                .Where(x => x.Language.Code == languageCode && x.IsDeleted == false && x.Language.IsDeleted == false).ToListAsync();
        }

        public async Task<List<City>> GetCitiesByCountAsync(int skipCount, int takeCount)
        {
            return await Context.Cities.Where(x => x.IsDeleted == false)
                .OrderByDescending(x => x.Id).Skip(skipCount).Take(takeCount).ToListAsync();
        }

        public async Task<City> GetCityWithIncludeAsync(int id)
        {
            return await Context.Cities.Include(x => x.Language)
                .FirstOrDefaultAsync(x => x.Id == id && x.IsDeleted == false && x.Language.IsDeleted == false);
        }

        public async Task<City> GetMultiLanguageCityAsync(int id, string languageCode)
        {
            return await Context.Cities.Include(x => x.Language)
                .FirstOrDefaultAsync(x => x.Language.Code == languageCode && x.IsDeleted == false && x.Language.IsDeleted == false);
        }
    }
}

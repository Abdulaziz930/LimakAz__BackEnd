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
    public class EFTariffDal : EFRepositoryBase<Tariff, AppDbContext>, ITariffDal
    {
        public async Task<List<CountryProductType>> GetMultiLanguageTrariffsWithIncludesAsync(string languageCode)
        {
            //var list = new List<Tariff>();
            await using var context = new AppDbContext();
            return await context.CountryProductTypes.Include(x => x.ProductType).ThenInclude(x => x.Tariffs)
                .ThenInclude(x => x.Language).Include(x => x.Country).ThenInclude(x => x.Tab).ToListAsync();
        }
    }
}

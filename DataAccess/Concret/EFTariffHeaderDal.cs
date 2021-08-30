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
    public class EFTariffHeaderDal : EFRepositoryBase<TariffHeader, AppDbContext>, ITariffHeaderDal
    {
        public EFTariffHeaderDal(AppDbContext context) : base(context)
        {
        }

        public async Task<TariffHeader> GetTariffHeaderAsync(string languageCode)
        {
            return await Context.TariffHeaders.Include(x => x.Language)
                .FirstOrDefaultAsync(x => x.IsDeleted == false && x.Language.IsDeleted == false && x.Language.Code == languageCode);
        }

        public async Task<List<TariffHeader>> GetTariffHeadersByCountAsync(int skipCount, int takeCount)
        {
            return await Context.TariffHeaders
                .Where(x => x.IsDeleted == false).OrderByDescending(x => x.Id)
                .Skip(skipCount).Take(takeCount).ToListAsync();
        }
    }
}

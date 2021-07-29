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
    public class EFUnitsOfLengthDal : EFRepositoryBase<UnitsOfLength, AppDbContext>, IUnitsOfLengthDal
    {
        public async Task<List<UnitsOfLength>> GetAllMultiLanguageUnitsOfLengthAsync(string languageCode)
        {
            await using var context = new AppDbContext();
            return await context.UnitsOfLengths.Include(x => x.Language)
                .Where(x => x.Language.Code == languageCode && x.Language.IsDeleted == false && x.IsDeleted == false).ToListAsync();
        }

        public async Task<List<UnitsOfLength>> GetUnitsOfLengthByCountAsync(int skipCount, int takeCount)
        {
            await using var context = new AppDbContext();
            return await context.UnitsOfLengths.Where(x => x.IsDeleted == false)
                .OrderByDescending(x => x.Id).Skip(skipCount).Take(takeCount).ToListAsync();
        }

        public async Task<UnitsOfLength> GetUnitsOfLengthWithIncludeAsync(int id)
        {
            await using var context = new AppDbContext();
            return await context.UnitsOfLengths.Include(x => x.Language)
                .FirstOrDefaultAsync(x => x.Id == id && x.IsDeleted == false && x.Language.IsDeleted == false);
        }
    }
}

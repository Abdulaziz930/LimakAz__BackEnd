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
    public class EFHowItWorkDal : EFRepositoryBase<HowItWork, AppDbContext>, IHowItWorkDal
    {

        public async Task<HowItWork> GetMultiLanguageHowItWorkAsync(string languageCode)
        {

            await using var context = new AppDbContext();
            return await context.HowItWorks.Include(x => x.Language)
                .FirstOrDefaultAsync(x => x.Language.Code == languageCode && x.Language.IsDeleted == false && x.IsDeleted == false);
        }

        public async Task<List<HowItWork>> GetHowItWorksByCountAsync(int skipCount, int takeCount)
        {
            await using var context = new AppDbContext();
            return await context.HowItWorks.Where(x => x.IsDeleted == false)
                .OrderByDescending(x => x.Id).Skip(skipCount).Take(takeCount).ToListAsync();
        }

        public async Task<HowItWork> GetHowItWorkWithIncludeAsync(int id)
        {
            await using var context = new AppDbContext();
            return await context.HowItWorks.Include(x => x.Language)
                .FirstOrDefaultAsync(x => x.Id == id && x.IsDeleted == false && x.Language.IsDeleted == false);
        }
    }
}

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

        public EFHowItWorkDal(AppDbContext context) : base(context)
        {
        }

        public async Task<HowItWork> GetMultiLanguageHowItWorkAsync(string languageCode)
        {

            return await Context.HowItWorks.Include(x => x.Language)
                .FirstOrDefaultAsync(x => x.Language.Code == languageCode && x.Language.IsDeleted == false && x.IsDeleted == false);
        }

        public async Task<List<HowItWork>> GetHowItWorksByCountAsync(int skipCount, int takeCount)
        {
            return await Context.HowItWorks.Where(x => x.IsDeleted == false)
                .OrderByDescending(x => x.Id).Skip(skipCount).Take(takeCount).ToListAsync();
        }

        public async Task<HowItWork> GetHowItWorkWithIncludeAsync(int id)
        {
            return await Context.HowItWorks.Include(x => x.Language)
                .FirstOrDefaultAsync(x => x.Id == id && x.IsDeleted == false && x.Language.IsDeleted == false);
        }
    }
}

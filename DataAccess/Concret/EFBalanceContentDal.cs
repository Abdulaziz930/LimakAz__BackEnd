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
    public class EFBalanceContentDal : EFRepositoryBase<BalanceContent, AppDbContext>, IBalanceContentDal
    {
        public async Task<BalanceContent> GetBalanceContentAsync(string languageCode)
        {
            await using var context = new AppDbContext();
            return await context.BalanceContents.Include(x => x.Language)
                .FirstOrDefaultAsync(x => x.Language.IsDeleted == false && x.Language.Code == languageCode);
        }

        public async Task<List<BalanceContent>> GetBalanceContentsByCountAsync(int skipCount, int takeCount)
        {
            await using var context = new AppDbContext();
            return await context.BalanceContents
                .OrderByDescending(x => x.Id)
                .Skip(skipCount).Take(takeCount).ToListAsync();
        }
    }
}

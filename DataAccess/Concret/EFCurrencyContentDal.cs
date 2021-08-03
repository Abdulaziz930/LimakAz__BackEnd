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
    public class EFCurrencyContentDal : EFRepositoryBase<CurrencyContent, AppDbContext>, ICurrencyContentDal
    {
        public async Task<List<CurrencyContent>> GetCurrencyContentsByCountAsync(int skipCount, int takeCount)
        {
            await using var context = new AppDbContext();
            return await context.CurrencyContents
                .Where(x => x.IsDeleted == false).OrderByDescending(x => x.Id)
                .Skip(skipCount).Take(takeCount).ToListAsync();
        }
    }
}

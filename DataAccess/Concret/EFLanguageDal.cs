using Core.Repository.EFRepository;
using DataAccess.Abstract;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concret
{
    public class EFLanguageDal : EFRepositoryBase<Language, AppDbContext>, ILangaugeDal
    {
        public async Task<List<Language>> GetLanguagesByCountAsync(int skipCount, int takeCount)
        {
            await using var context = new AppDbContext();
            return await context.Languages.Where(x => x.IsDeleted == false)
                .OrderByDescending(x => x.Id).Skip(skipCount).Take(takeCount).ToListAsync();
        }

        public async Task<bool> CheckLanguagesAsync(Expression<Func<Language, bool>> filter)
        {
            await using var context = new AppDbContext();
            return await context.Languages.AnyAsync(filter);
        }
    }
}

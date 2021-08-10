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
    public class EFUserRuleDal : EFRepositoryBase<UserRule, AppDbContext>, IUserRuleDal
    {
        public async Task<UserRule> GetMultiLanguageUserRuleAsync(string languageCode)
        {
            await using var context = new AppDbContext();
            return await context.UserRules
                .Include(x => x.Language)
                .FirstOrDefaultAsync(x => x.IsDeleted == false && x.Language.IsDeleted == false && x.Language.Code == languageCode);
        }

        public async Task<List<UserRule>> GetUserRulesByCountAsync(int skipCount, int takeCount)
        {
            await using var context = new AppDbContext();
            return await context.UserRules.Where(x => x.IsDeleted == false)
                .Skip(skipCount).Take(takeCount).ToListAsync();
        }

        public async Task<UserRule> GetUserRuleWithInclude(int id)
        {
            await using var context = new AppDbContext();
            return await context.UserRules.Include(x => x.Language)
                .FirstOrDefaultAsync(x => x.Id == id && x.IsDeleted == false && x.Language.IsDeleted == false);
        }
    }
}

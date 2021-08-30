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
    public class EFRuleContentDal : EFRepositoryBase<RuleContent, AppDbContext>, IRuleContentDal
    {
        public EFRuleContentDal(AppDbContext context) : base(context)
        {
        }

        public async Task<RuleContent> GetRuleContentAsync(string languageCode)
        {
            return await Context.RuleContents.Include(x => x.Language)
                .FirstOrDefaultAsync(x => x.IsDeleted == false && x.Language.IsDeleted == false && x.Language.Code == languageCode);
        }

        public async Task<List<RuleContent>> GetRuleContentsByCountAsync(int skipCount, int takeCount)
        {
            return await Context.RuleContents
                .Where(x => x.IsDeleted == false).OrderByDescending(x => x.Id)
                .Skip(skipCount).Take(takeCount).ToListAsync();
        }
    }
}

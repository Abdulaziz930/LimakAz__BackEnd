using Buisness.Abstract;
using DataAccess.Abstract;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Buisness.Concret
{
    public class RuleContentManager : IRuleContentService
    {
        private readonly IRuleContentDal _ruleContentDal;

        public RuleContentManager(IRuleContentDal ruleContentDal)
        {
            _ruleContentDal = ruleContentDal;
        }

        public async Task<bool> AddAsync(RuleContent ruleContent)
        {
            await _ruleContentDal.AddAsync(ruleContent);

            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            await _ruleContentDal.DeleteAsync(new RuleContent { Id = id });

            return true;
        }

        public async Task<List<RuleContent>> GetAllRuleContentsAsync()
        {
            return await _ruleContentDal.GetAllAsync(x => x.IsDeleted == false);
        }

        public async Task<List<RuleContent>> GetAllRuleContentsAsync(int skipCount, int takeCount)
        {
            return await _ruleContentDal.GetRuleContentsByCountAsync(skipCount, takeCount);
        }

        public async Task<RuleContent> GetRuleContentAsync(int id)
        {
            return await _ruleContentDal.GetAsync(x => x.Id == id && x.IsDeleted == false);
        }

        public async Task<RuleContent> GetRuleContentAsync(string languageCode)
        {
            return await _ruleContentDal.GetRuleContentAsync(languageCode);
        }

        public async Task<bool> UpdateAsync(RuleContent ruleContent)
        {
            await _ruleContentDal.UpdateAsync(ruleContent);

            return true;
        }
    }
}

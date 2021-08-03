using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Buisness.Abstract
{
    public interface IRuleContentService
    {
        Task<RuleContent> GetRuleContentAsync(int id);

        Task<RuleContent> GetRuleContentAsync(string languageCode);

        Task<List<RuleContent>> GetAllRuleContentsAsync();

        Task<List<RuleContent>> GetAllRuleContentsAsync(int skipCount, int takeCount);

        Task<bool> AddAsync(RuleContent ruleContent);

        Task<bool> UpdateAsync(RuleContent ruleContent);

        Task<bool> DeleteAsync(int id);
    }
}

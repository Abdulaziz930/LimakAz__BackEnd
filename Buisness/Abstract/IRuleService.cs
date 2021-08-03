using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Buisness.Abstract
{
    public interface IRuleService
    {
        Task<Rule> GetRuleAsync(int id);

        Task<Rule> GetRuleWithLanguageAsync(int id);

        Task<List<Rule>> GetAllRulesAsync();

        Task<List<Rule>> GetAllRulesAsync(string langaugeCode);

        Task<List<Rule>> GetAllRulesAsync(int skipCount, int takeCount);

        Task<bool> AddAsync(Rule rule);

        Task<bool> UpdateAsync(Rule rule);

        Task<bool> DeleteAsync(int id);
    }
}

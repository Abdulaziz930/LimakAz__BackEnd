using Buisness.Abstract;
using DataAccess.Abstract;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Buisness.Concret
{
    public class RuleManager : IRuleService
    {
        private readonly IRuleDal _ruleDal;

        public RuleManager(IRuleDal ruleDal)
        {
            _ruleDal = ruleDal;
        }

        public async Task<bool> AddAsync(Rule rule)
        {
            await _ruleDal.AddAsync(rule);

            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            await _ruleDal.DeleteAsync(new Rule { Id = id });

            return true;
        }

        public async Task<List<Rule>> GetAllRulesAsync()
        {
            return await _ruleDal.GetAllAsync(x => x.IsDeleted == false);
        }

        public async Task<List<Rule>> GetAllRulesAsync(string langaugeCode)
        {
            return await _ruleDal.GetAllMultiLanguageRulesAsync(langaugeCode);
        }

        public async Task<List<Rule>> GetAllRulesAsync(int skipCount, int takeCount)
        {
            return await _ruleDal.GetRulesByCountAsync(skipCount, takeCount);
        }

        public async Task<Rule> GetRuleAsync(int id)
        {
            return await _ruleDal.GetAsync(x => x.Id == id && x.IsDeleted == false);
        }

        public async Task<Rule> GetRuleWithLanguageAsync(int id)
        {
            return await _ruleDal.GetRuleWithInclude(id);
        }

        public async Task<bool> UpdateAsync(Rule rule)
        {
            await _ruleDal.UpdateAsync(rule);

            return true;
        }
    }
}

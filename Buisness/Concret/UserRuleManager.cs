using Buisness.Abstract;
using DataAccess.Abstract;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Buisness.Concret
{
    public class UserRuleManager : IUserRuleService
    {
        private readonly IUserRuleDal _userRuleDal;

        public UserRuleManager(IUserRuleDal userRuleDal)
        {
            _userRuleDal = userRuleDal;
        }

        public async Task<bool> AddAsync(UserRule userRule)
        {
            await _userRuleDal.AddAsync(userRule);

            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            await _userRuleDal.DeleteAsync(new UserRule { Id = id });

            return true;
        }

        public async Task<List<UserRule>> GetAllUserRulesAsync()
        {
            return await _userRuleDal.GetAllAsync(x => x.IsDeleted == false);
        }

        public async Task<List<UserRule>> GetAllUserRulesAsync(int skipCount, int takeCount)
        {
            return await _userRuleDal.GetUserRulesByCountAsync(skipCount, takeCount);
        }

        public async Task<UserRule> GetUserRuleAsync(int id)
        {
            return await _userRuleDal.GetAsync(x => x.Id == id && x.IsDeleted == false);
        }

        public async Task<UserRule> GetUserRuleWithLanguageAsync(int id)
        {
            return await _userRuleDal.GetUserRuleWithInclude(id);
        }

        public async Task<UserRule> GetUserRuleAsync(string langaugeCode)
        {
            return await _userRuleDal.GetMultiLanguageUserRuleAsync(langaugeCode);
        }

        public async Task<bool> UpdateAsync(UserRule userRule)
        {
            await _userRuleDal.UpdateAsync(userRule);

            return true;
        }
    }
}

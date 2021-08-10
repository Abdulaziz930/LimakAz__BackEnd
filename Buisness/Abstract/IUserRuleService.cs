using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Buisness.Abstract
{
    public interface IUserRuleService
    {
        Task<UserRule> GetUserRuleAsync(int id);

        Task<UserRule> GetUserRuleWithLanguageAsync(int id);

        Task<UserRule> GetUserRuleAsync(string langaugeCode);

        Task<List<UserRule>> GetAllUserRulesAsync();

        Task<List<UserRule>> GetAllUserRulesAsync(int skipCount, int takeCount);

        Task<bool> AddAsync(UserRule userRule);

        Task<bool> UpdateAsync(UserRule userRule);

        Task<bool> DeleteAsync(int id);
    }
}

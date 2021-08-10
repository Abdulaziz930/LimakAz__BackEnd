using Core.Repository;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IUserRuleDal : IRepository<UserRule>
    {
        Task<UserRule> GetUserRuleWithInclude(int id);

        Task<UserRule> GetMultiLanguageUserRuleAsync(string languageCode);

        Task<List<UserRule>> GetUserRulesByCountAsync(int skipCount, int takeCount);
    }
}

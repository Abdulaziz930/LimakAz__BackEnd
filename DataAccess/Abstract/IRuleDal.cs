using Core.Repository;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IRuleDal : IRepository<Rule>
    {
        Task<Rule> GetRuleWithInclude(int id);

        Task<List<Rule>> GetAllMultiLanguageRulesAsync(string languageCode);

        Task<List<Rule>> GetRulesByCountAsync(int skipCount, int takeCount);
    }
}

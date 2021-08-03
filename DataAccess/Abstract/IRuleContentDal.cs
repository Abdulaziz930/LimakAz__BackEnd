using Core.Repository;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IRuleContentDal : IRepository<RuleContent>
    {
        Task<RuleContent> GetRuleContentAsync(string languageCode);

        Task<List<RuleContent>> GetRuleContentsByCountAsync(int skipCount, int takeCount);
    }
}

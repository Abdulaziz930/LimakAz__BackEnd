using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Buisness.Abstract
{
    public interface IBalanceContentService
    {
        Task<BalanceContent> GetBalanceContentAsync(int id);

        Task<BalanceContent> GetBalanceContentAsync(string languageCode);

        Task<List<BalanceContent>> GetAllBalanceContentsAsync();

        Task<List<BalanceContent>> GetAllBalanceContentsAsync(int skipCount, int takeCount);

        Task<bool> AddAsync(BalanceContent balanceContent);

        Task<bool> UpdateAsync(BalanceContent balanceContent);

        Task<bool> DeleteAsync(int id);
    }
}

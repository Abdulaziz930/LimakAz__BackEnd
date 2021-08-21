using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Buisness.Abstract
{
    public interface IBalanceModalContentService
    {
        Task<BalanceModalContent> GetBalanceModalContentAsync(int id);

        Task<BalanceModalContent> GetBalanceModalContentAsync(string languageCode);

        Task<List<BalanceModalContent>> GetAllBalanceModalContentsAsync();

        Task<bool> AddAsync(BalanceModalContent balanceModalContent);

        Task<bool> UpdateAsync(BalanceModalContent balanceModalContent);

        Task<bool> DeleteAsync(int id);
    }
}

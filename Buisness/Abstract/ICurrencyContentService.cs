using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Buisness.Abstract
{
    public interface ICurrencyContentService
    {
        Task<CurrencyContent> GetCurrencyContentAsync(int id);

        Task<List<CurrencyContent>> GetAllCurrencyContentsAsync();

        Task<List<CurrencyContent>> GetAllCurrencyContentsAsync(int skipCount, int takeCount);

        Task<bool> AddAsync(CurrencyContent currencyContent);

        Task<bool> UpdateAsync(CurrencyContent currencyContent);

        Task<bool> DeleteAsync(int id);
    }
}

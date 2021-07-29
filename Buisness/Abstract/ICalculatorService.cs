using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Buisness.Abstract
{
    public interface ICalculatorService
    {
        Task<Calculator> GetCalculatorAsync(int id);

        Task<Calculator> GetCalculatorWithLanguageAsync(int id);

        Task<Calculator> GetCalculatorAsync(string languageCode);

        Task<List<Calculator>> GetAllCalculatorContentsAsync();

        Task<List<Calculator>> GetAllCalculatorContentsAsync(int skipCount,int takeCount);

        Task<bool> AddAsync(Calculator calculator);

        Task<bool> UpdateAsync(Calculator calculator);

        Task<bool> DeleteAsync(int id);
    }
}

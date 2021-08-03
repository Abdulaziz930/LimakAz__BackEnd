using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Buisness.Abstract
{
    public interface ICalculatorContentService
    {
        Task<CalculatorContent> GetCalculatorContentAsync(int id);

        Task<CalculatorContent> GetCalculatorContentAsync(string languageCode);

        Task<List<CalculatorContent>> GetAllCalculatorContentsAsync();

        Task<List<CalculatorContent>> GetAllCalculatorContentsAsync(int skipCount, int takeCount);

        Task<bool> AddAsync(CalculatorContent calculatorContent);

        Task<bool> UpdateAsync(CalculatorContent calculatorContent);

        Task<bool> DeleteAsync(int id);
    }
}

using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Buisness.Abstract
{
    public interface ICalculatorInformationContentService
    {
        Task<CalculatorIntormationContent> GetCalculatorIntormationContentAsync(int id);

        Task<List<CalculatorIntormationContent>> GetCalculatorIntormationContentsAsync();

        Task<List<CalculatorIntormationContent>> GetAllCalculatorIntormationContentsAsync(string languageCode);

        Task<List<CalculatorIntormationContent>> GetAllCalculatorIntormationContentsAsync(int skipCount, int takeCount);

        Task<bool> AddAsync(CalculatorIntormationContent calculatorIntormationContent);

        Task<bool> UpdateAsync(CalculatorIntormationContent calculatorIntormationContent);

        Task<bool> DeleteAsync(int id);
    }
}

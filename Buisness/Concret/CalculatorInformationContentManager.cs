using Buisness.Abstract;
using DataAccess.Abstract;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Buisness.Concret
{
    public class CalculatorInformationContentManager : ICalculatorInformationContentService
    {
        private readonly ICalculatorInformationContentDal _calculatorInformationContentDal;

        public CalculatorInformationContentManager(ICalculatorInformationContentDal calculatorInformationContentDal)
        {
            _calculatorInformationContentDal = calculatorInformationContentDal;
        }

        public async Task<bool> AddAsync(CalculatorIntormationContent calculatorIntormationContent)
        {
            await _calculatorInformationContentDal.AddAsync(calculatorIntormationContent);

            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            await _calculatorInformationContentDal.DeleteAsync(new CalculatorIntormationContent { Id = id });

            return true;
        }

        public async Task<List<CalculatorIntormationContent>> GetAllCalculatorIntormationContentsAsync(int skipCount, int takeCount)
        {
            return await _calculatorInformationContentDal.GetCalculatorIntormationContentsByCountAsync(skipCount, takeCount);
        }

        public async Task<CalculatorIntormationContent> GetCalculatorIntormationContentAsync(int id)
        {
            return await _calculatorInformationContentDal.GetAsync(x => x.Id == id && x.IsDeleted == false);
        }

        public async Task<List<CalculatorIntormationContent>> GetAllCalculatorIntormationContentsAsync(string languageCode)
        {
            return await _calculatorInformationContentDal.GetCalculatorIntormationContentsAsync(languageCode);
        }

        public async Task<List<CalculatorIntormationContent>> GetCalculatorIntormationContentsAsync()
        {
            return await _calculatorInformationContentDal.GetAllAsync(x => x.IsDeleted == false);
        }

        public async Task<bool> UpdateAsync(CalculatorIntormationContent calculatorIntormationContent)
        {
            await _calculatorInformationContentDal.UpdateAsync(calculatorIntormationContent);

            return true;
        }
    }
}

using Buisness.Abstract;
using DataAccess.Abstract;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Buisness.Concret
{
    public class CalculatorContentManager : ICalculatorContentService
    {
        private readonly ICalculatorContentDal _calculatorContentDal;

        public CalculatorContentManager(ICalculatorContentDal calculatorContentDal)
        {
            _calculatorContentDal = calculatorContentDal;
        }

        public async Task<bool> AddAsync(CalculatorContent calculatorContent)
        {
            await _calculatorContentDal.AddAsync(calculatorContent);

            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            await _calculatorContentDal.DeleteAsync(new CalculatorContent { Id = id });

            return true;
        }

        public async Task<List<CalculatorContent>> GetAllCalculatorContentsAsync()
        {
            return await _calculatorContentDal.GetAllAsync(x => x.IsDeleted == false);
        }

        public async Task<List<CalculatorContent>> GetAllCalculatorContentsAsync(int skipCount, int takeCount)
        {
            return await _calculatorContentDal.GetCalculatorContentsByCountAsync(skipCount, takeCount);
        }

        public async Task<CalculatorContent> GetCalculatorContentAsync(int id)
        {
            return await _calculatorContentDal.GetAsync(x => x.Id == id && x.IsDeleted == false);
        }

        public async Task<CalculatorContent> GetCalculatorContentAsync(string languageCode)
        {
            return await _calculatorContentDal.GetCalculatorContentAsync(languageCode);
        }

        public async Task<bool> UpdateAsync(CalculatorContent calculatorContent)
        {
            await _calculatorContentDal.UpdateAsync(calculatorContent);

            return true;
        }
    }
}

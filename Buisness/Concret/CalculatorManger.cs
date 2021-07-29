using Buisness.Abstract;
using DataAccess.Abstract;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Buisness.Concret
{
    public class CalculatorManger : ICalculatorService
    {
        private readonly ICalculatorDal _calculatorDal;

        public CalculatorManger(ICalculatorDal calculatorDal)
        {
            _calculatorDal = calculatorDal;
        }

        public async Task<bool> AddAsync(Calculator calculator)
        {
            await _calculatorDal.AddAsync(calculator);

            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            await _calculatorDal.DeleteAsync(new Calculator { Id = id });

            return true;
        }

        public async Task<List<Calculator>> GetAllCalculatorContentsAsync()
        {
            return await _calculatorDal.GetAllAsync();
        }

        public async Task<List<Calculator>> GetAllCalculatorContentsAsync(int skipCount, int takeCount)
        {
            return await _calculatorDal.GetAllCalculatorContentsByCountAsync(skipCount, takeCount);
        }

        public async Task<Calculator> GetCalculatorAsync(int id)
        {
            return await _calculatorDal.GetAsync(x => x.Id == id && x.IsDeleted == false);
        }

        public async Task<Calculator> GetCalculatorAsync(string languageCode)
        {
            return await _calculatorDal.GetMultiLanguageCalculatorAsync(languageCode);
        }

        public async Task<Calculator> GetCalculatorWithLanguageAsync(int id)
        {
            return await _calculatorDal.GetCalculatorWithIncludeAsync(id);
        }

        public async Task<bool> UpdateAsync(Calculator calculator)
        {
            await _calculatorDal.UpdateAsync(calculator);

            return true;
        }
    }
}

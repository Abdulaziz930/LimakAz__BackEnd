using Buisness.Abstract;
using DataAccess.Abstract;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Buisness.Concret
{
    public class CurrencyContentManager : ICurrencyContentService
    {
        private readonly ICurrencyContentDal _currencyContentDal;

        public CurrencyContentManager(ICurrencyContentDal currencyContentDal)
        {
            _currencyContentDal = currencyContentDal;
        }

        public async Task<bool> AddAsync(CurrencyContent currencyContent)
        {
            await _currencyContentDal.AddAsync(currencyContent);

            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            await _currencyContentDal.DeleteAsync(new CurrencyContent { Id = id });

            return true;
        }

        public async Task<List<CurrencyContent>> GetAllCurrencyContentsAsync()
        {
           return await _currencyContentDal.GetAllAsync(x => x.IsDeleted == false);
        }

        public async Task<List<CurrencyContent>> GetAllCurrencyContentsAsync(int skipCount, int takeCount)
        {
            return await _currencyContentDal.GetCurrencyContentsByCountAsync(skipCount, takeCount);
        }

        public async Task<CurrencyContent> GetCurrencyContentAsync(int id)
        {
            return await _currencyContentDal.GetAsync(x => x.Id == id && x.IsDeleted == false);
        }

        public async Task<bool> UpdateAsync(CurrencyContent currencyContent)
        {
            await _currencyContentDal.UpdateAsync(currencyContent);

            return true;
        }
    }
}

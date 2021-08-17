using Buisness.Abstract;
using DataAccess.Abstract;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Buisness.Concret
{
    public class BalanceContentMananger : IBalanceContentService
    {
        private readonly IBalanceContentDal _balanceContentDal;

        public BalanceContentMananger(IBalanceContentDal balanceContentDal)
        {
            _balanceContentDal = balanceContentDal;
        }

        public async Task<bool> AddAsync(BalanceContent balanceContent)
        {
            await _balanceContentDal.AddAsync(balanceContent);

            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            await _balanceContentDal.DeleteAsync(new BalanceContent { Id = id });

            return true;
        }

        public async Task<List<BalanceContent>> GetAllBalanceContentsAsync()
        {
            return await _balanceContentDal.GetAllAsync();
        }

        public async Task<List<BalanceContent>> GetAllBalanceContentsAsync(int skipCount, int takeCount)
        {
            return await _balanceContentDal.GetBalanceContentsByCountAsync(skipCount, takeCount);
        }

        public async Task<BalanceContent> GetBalanceContentAsync(int id)
        {
            return await _balanceContentDal.GetAsync(x => x.Id == id);
        }

        public async Task<BalanceContent> GetBalanceContentAsync(string languageCode)
        {
            return await _balanceContentDal.GetBalanceContentAsync(languageCode);
        }

        public async Task<bool> UpdateAsync(BalanceContent balanceContent)
        {
            await _balanceContentDal.UpdateAsync(balanceContent);

            return true;
        }
    }
}

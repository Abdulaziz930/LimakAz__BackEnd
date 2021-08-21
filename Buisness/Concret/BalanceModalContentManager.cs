using Buisness.Abstract;
using DataAccess.Abstract;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Buisness.Concret
{
    public class BalanceModalContentManager : IBalanceModalContentService
    {
        private readonly IBalanceModalContentDal _balanceModalContentDal;

        public BalanceModalContentManager(IBalanceModalContentDal balanceModalContentDal)
        {
            _balanceModalContentDal = balanceModalContentDal;
        }

        public async Task<bool> AddAsync(BalanceModalContent balanceModalContent)
        {
            await _balanceModalContentDal.AddAsync(balanceModalContent);

            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            await _balanceModalContentDal.DeleteAsync(new BalanceModalContent { Id = id });

            return true;
        }

        public async Task<List<BalanceModalContent>> GetAllBalanceModalContentsAsync()
        {
            return await _balanceModalContentDal.GetAllAsync();
        }

        public async Task<BalanceModalContent> GetBalanceModalContentAsync(int id)
        {
            return await _balanceModalContentDal.GetAsync(x => x.Id == id);
        }

        public async Task<BalanceModalContent> GetBalanceModalContentAsync(string languageCode)
        {
            return await _balanceModalContentDal.GetBalanceModalContentAsync(languageCode);
        }

        public async Task<bool> UpdateAsync(BalanceModalContent balanceModalContent)
        {
            await _balanceModalContentDal.UpdateAsync(balanceModalContent);

            return true;
        }
    }
}

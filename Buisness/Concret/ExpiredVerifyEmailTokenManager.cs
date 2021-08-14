using Buisness.Abstract;
using DataAccess.Abstract;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Buisness.Concret
{
    public class ExpiredVerifyEmailTokenManager : IExpiredVerifyEmailTokenService
    {
        private readonly IExpiredVerifyEmailTokenDal _expiredVerifyEmailTokenDal;

        public ExpiredVerifyEmailTokenManager(IExpiredVerifyEmailTokenDal expiredVerifyEmailTokenDal)
        {
            _expiredVerifyEmailTokenDal = expiredVerifyEmailTokenDal;
        }

        public async Task<bool> AddAsync(ExpiredVerifyEmailToken token)
        {
            await _expiredVerifyEmailTokenDal.AddAsync(token);

            return true;
        }

        public async Task<bool> DeleteAsync(ExpiredVerifyEmailToken token)
        {
            await _expiredVerifyEmailTokenDal.DeleteAsync(new ExpiredVerifyEmailToken { Id = token.Id });

            return true;
        }

        public async Task<List<ExpiredVerifyEmailToken>> GetAllExpiredVerifyEmailTokensAsync()
        {
            return await _expiredVerifyEmailTokenDal.GetAllAsync();
        }

        public async Task<ExpiredVerifyEmailToken> GetExpiredVerifyEmailTokeAsync(int id)
        {
            return await _expiredVerifyEmailTokenDal.GetAsync(x => x.Id == id);
        }

        public async Task<bool> GetExpiredVerifyEmailTokeAsync(string token)
        {
            return await _expiredVerifyEmailTokenDal.GetExpiredEmailTokenByTokenAsync(token);
        }

        public async Task<bool> UpdateAsync(ExpiredVerifyEmailToken token)
        {
            await _expiredVerifyEmailTokenDal.UpdateAsync(token);

            return true;
        }
    }
}

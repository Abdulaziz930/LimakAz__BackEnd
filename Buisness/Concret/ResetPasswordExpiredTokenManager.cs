using Buisness.Abstract;
using DataAccess.Abstract;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Buisness.Concret
{
    public class ResetPasswordExpiredTokenManager : IResetPasswordExpiredTokenService
    {
        private readonly IResetPasswordExpiredTokenDal _resetPasswordExpiredTokenDal;

        public ResetPasswordExpiredTokenManager(IResetPasswordExpiredTokenDal resetPasswordExpiredTokenDal)
        {
            _resetPasswordExpiredTokenDal = resetPasswordExpiredTokenDal;
        }

        public async Task<bool> AddAsync(ResetPasswordExpiredToken token)
        {
            await _resetPasswordExpiredTokenDal.AddAsync(token);

            return true;
        }

        public async Task<bool> CheckExpiredVerifyEmailTokeAsync(string token)
        {
            return await _resetPasswordExpiredTokenDal.CheckTokenIsExistAsync(token);
        }

        public async Task<bool> DeleteAsync(ResetPasswordExpiredToken token)
        {
            await _resetPasswordExpiredTokenDal.DeleteAsync(new ResetPasswordExpiredToken { Id = token.Id });

            return true;
        }

        public async Task<List<ResetPasswordExpiredToken>> GetAllResetPasswordExpiredTokensAsync()
        {
            return await _resetPasswordExpiredTokenDal.GetAllAsync();
        }

        public async Task<ResetPasswordExpiredToken> GetResetPasswordExpiredTokenAsync(int id)
        {
            return await _resetPasswordExpiredTokenDal.GetAsync(x => x.Id == id);
        }

        public async Task<bool> UpdateAsync(ResetPasswordExpiredToken token)
        {
            await _resetPasswordExpiredTokenDal.UpdateAsync(token);

            return true;
        }
    }
}

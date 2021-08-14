using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Buisness.Abstract
{
    public interface IResetPasswordExpiredTokenService
    {
        Task<ResetPasswordExpiredToken> GetResetPasswordExpiredTokenAsync(int id);

        Task<List<ResetPasswordExpiredToken>> GetAllResetPasswordExpiredTokensAsync();

        Task<bool> AddAsync(ResetPasswordExpiredToken token);

        Task<bool> UpdateAsync(ResetPasswordExpiredToken token);

        Task<bool> DeleteAsync(ResetPasswordExpiredToken token);

        Task<bool> CheckExpiredVerifyEmailTokeAsync(string token);
    }
}

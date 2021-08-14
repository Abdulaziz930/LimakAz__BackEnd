using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Buisness.Abstract
{
    public interface IExpiredVerifyEmailTokenService
    {
        Task<ExpiredVerifyEmailToken> GetExpiredVerifyEmailTokeAsync(int id);

        Task<bool> GetExpiredVerifyEmailTokeAsync(string token);

        Task<List<ExpiredVerifyEmailToken>> GetAllExpiredVerifyEmailTokensAsync();

        Task<bool> AddAsync(ExpiredVerifyEmailToken token);

        Task<bool> UpdateAsync(ExpiredVerifyEmailToken token);

        Task<bool> DeleteAsync(ExpiredVerifyEmailToken token);
    }
}

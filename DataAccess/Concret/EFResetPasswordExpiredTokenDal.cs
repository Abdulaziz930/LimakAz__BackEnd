using Core.Repository.EFRepository;
using DataAccess.Abstract;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concret
{
    public class EFResetPasswordExpiredTokenDal : EFRepositoryBase<ResetPasswordExpiredToken, AppDbContext>, IResetPasswordExpiredTokenDal
    {
        public async Task<bool> CheckTokenIsExistAsync(string token)
        {
            await using var context = new AppDbContext();
            return await context.ResetPasswordExpiredTokens.AnyAsync(x => x.Token == token);
        }
    }
}

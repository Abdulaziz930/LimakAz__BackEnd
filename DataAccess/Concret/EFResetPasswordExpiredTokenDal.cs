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
        public EFResetPasswordExpiredTokenDal(AppDbContext context) : base(context)
        {
        }

        public async Task<bool> CheckTokenIsExistAsync(string token)
        {
            return await Context.ResetPasswordExpiredTokens.AnyAsync(x => x.Token == token);
        }
    }
}

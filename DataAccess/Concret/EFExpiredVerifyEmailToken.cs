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
    public class EFExpiredVerifyEmailToken : EFRepositoryBase<ExpiredVerifyEmailToken, AppDbContext>, IExpiredVerifyEmailTokenDal
    {
        public EFExpiredVerifyEmailToken(AppDbContext context) : base(context)
        {
        }

        public async Task<bool> GetExpiredEmailTokenByTokenAsync(string token)
        {
            return await Context.ExpiredVerifyEmailTokens.AnyAsync(x => x.Token == token);
        }
    }
}

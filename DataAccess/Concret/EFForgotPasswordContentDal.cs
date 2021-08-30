using Core.Repository.EFRepository;
using DataAccess.Abstract;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concret
{
    public class EFForgotPasswordContentDal : EFRepositoryBase<ForgotPasswordContent, AppDbContext>, IForgotPasswordContentDal
    {
        public EFForgotPasswordContentDal(AppDbContext context) : base(context)
        {
        }

        public async Task<ForgotPasswordContent> GetForgotPasswordContentAsync(string languageCode)
        {
            return await Context.ForgotPasswordContents.Include(x => x.Language)
                .FirstOrDefaultAsync(x => x.Language.IsDeleted == false && x.Language.Code == languageCode);
        }

        public async Task<List<ForgotPasswordContent>> GetForgotPasswordContentsByCountAsync(int skipCount, int takeCount)
        {
            return await Context.ForgotPasswordContents
                .OrderByDescending(x => x.Id)
                .Skip(skipCount).Take(takeCount).ToListAsync();
        }
    }
}

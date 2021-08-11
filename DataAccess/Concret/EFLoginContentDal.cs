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
    public class EFLoginContentDal : EFRepositoryBase<LoginContent, AppDbContext>, ILoginContentDal
    {
        public async Task<LoginContent> GetLoginContentAsync(string languageCode)
        {
            await using var context = new AppDbContext();
            return await context.LoginContents.Include(x => x.Language)
                .FirstOrDefaultAsync(x => x.Language.IsDeleted == false && x.Language.Code == languageCode);
        }

        public async Task<List<LoginContent>> GetLoginContentsByCountAsync(int skipCount, int takeCount)
        {
            await using var context = new AppDbContext();
            return await context.LoginContents
                .OrderByDescending(x => x.Id)
                .Skip(skipCount).Take(takeCount).ToListAsync();
        }
    }
}

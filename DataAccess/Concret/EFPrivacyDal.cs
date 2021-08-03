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
    public class EFPrivacyDal : EFRepositoryBase<Privacy, AppDbContext>, IPrivacyDal
    {
        public async Task<List<Privacy>> GetPrivaciesByCountAsync(int skipCount, int takeCount)
        {
            await using var context = new AppDbContext();
            return await context.Privacies
                .Where(x => x.IsDeleted == false).OrderByDescending(x => x.Id)
                .Skip(skipCount).Take(takeCount).ToListAsync();
        }

        public async Task<Privacy> GetPrivacyAsync(string languageCode)
        {
            await using var context = new AppDbContext();
            return await context.Privacies.Include(x => x.Language)
                .FirstOrDefaultAsync(x => x.IsDeleted == false && x.Language.IsDeleted == false && x.Language.Code == languageCode);
        }

        public async Task<Privacy> GetPrivacyWithInclude(int id)
        {
            await using var context = new AppDbContext();
            return await context.Privacies.Include(x => x.Language)
                .FirstOrDefaultAsync(x => x.Id == id && x.IsDeleted == false && x.Language.IsDeleted == false);
        }
    }
}

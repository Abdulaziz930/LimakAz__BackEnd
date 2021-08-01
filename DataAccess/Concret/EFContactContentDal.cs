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
    public class EFContactContentDal : EFRepositoryBase<ContactContent, AppDbContext>, IContactContentDal
    {
        public async Task<ContactContent> GetContactContent(string languageCode)
        {
            await using var context = new AppDbContext();
            return await context.ContactContents.Include(x => x.Language)
                .FirstOrDefaultAsync(x => x.IsDeleted == false && x.Language.IsDeleted == false && x.Language.Code == languageCode);
        }

        public async Task<List<ContactContent>> GetContactContentsByCountAsync(int skipCount, int takeCount)
        {
            await using var context = new AppDbContext();
            return await context.ContactContents
                .Where(x => x.IsDeleted == false).OrderByDescending(x => x.Id).Skip(skipCount).Take(takeCount).ToListAsync();
        }
    }
}

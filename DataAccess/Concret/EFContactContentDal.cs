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
        public EFContactContentDal(AppDbContext context) : base(context)
        {
        }

        public async Task<ContactContent> GetContactContentAsync(string languageCode)
        {
            return await Context.ContactContents.Include(x => x.Language)
                .FirstOrDefaultAsync(x => x.IsDeleted == false && x.Language.IsDeleted == false && x.Language.Code == languageCode);
        }

        public async Task<List<ContactContent>> GetContactContentsByCountAsync(int skipCount, int takeCount)
        {
            return await Context.ContactContents
                .Where(x => x.IsDeleted == false).OrderByDescending(x => x.Id).Skip(skipCount).Take(takeCount).ToListAsync();
        }
    }
}

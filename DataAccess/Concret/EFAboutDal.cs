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
    public class EFAboutDal : EFRepositoryBase<About, AppDbContext>, IAboutDal
    {

        public EFAboutDal(AppDbContext context) : base(context)
        {
        }

        public async Task<About> GetAboutAsync(string languageCode)
        {
            return await Context.Abouts.Include(x => x.Language)
                .FirstOrDefaultAsync(x => x.IsDeleted == false && x.Language.IsDeleted == false && x.Language.Code == languageCode);
        }

        public async Task<List<About>> GetAboutsByCountAsync(int skipCount, int takeCount)
        {
            return await Context.Abouts
                .Where(x => x.IsDeleted == false).OrderByDescending(x => x.Id)
                .Skip(skipCount).Take(takeCount).ToListAsync();
        }

        public async Task<About> GetAboutWithInclude(int id)
        {
            return await Context.Abouts.Include(x => x.Language)
                .FirstOrDefaultAsync(x => x.Id == id && x.IsDeleted == false && x.Language.IsDeleted == false);
        }
    }
}

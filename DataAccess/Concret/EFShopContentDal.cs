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
    public class EFShopContentDal : EFRepositoryBase<ShopContent, AppDbContext>, IShopContentDal
    {
        public EFShopContentDal(AppDbContext context) : base(context)
        {
        }

        public async Task<ShopContent> GetShopContentAsync(string languageCode)
        {
            return await Context.ShopContents.Include(x => x.Language)
                .FirstOrDefaultAsync(x => x.IsDeleted == false && x.Language.IsDeleted == false && x.Language.Code == languageCode);
        }

        public async Task<List<ShopContent>> GetShopContentsByCountAsync(int skipCount, int takeCount)
        {
            return await Context.ShopContents
                .Where(x => x.IsDeleted == false).OrderByDescending(x => x.Id)
                .Skip(skipCount).Take(takeCount).ToListAsync();
        }
    }
}

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
    public class EFProductTypeDal : EFRepositoryBase<ProductType, AppDbContext>, IProductTypeDal
    {
        public EFProductTypeDal(AppDbContext context) : base(context)
        {
        }

        public async Task<List<ProductType>> GetAllMultiLanguageProductTypeAsync(string languageCode)
        {
            return await Context.ProductTypes.Include(x => x.Language)
                .Where(x => x.Language.Code == languageCode && x.Language.IsDeleted == false && x.IsDeleted == false).ToListAsync();
        }

        public async Task<List<ProductType>> GetAllMultiLanguageProductTypeWhithIncludeAsync(string languageCode)
        {
            return await Context.ProductTypes.Include(x => x.Language).Include(x => x.Tariffs)
                .Where(x => x.Language.Code == languageCode && x.Language.IsDeleted == false && x.IsDeleted == false).ToListAsync();
        }

        public async Task<List<ProductType>> GetProductTypesByCountAsync(int skipCount, int takeCount)
        {
            return await Context.ProductTypes.Where(x => x.IsDeleted == false)
                .OrderByDescending(x => x.Id).Skip(skipCount).Take(takeCount).ToListAsync();
        }

        public async Task<ProductType> GetProductTypeWithIncludeAsync(int id)
        {
            return await Context.ProductTypes.Include(x => x.Language)
                .FirstOrDefaultAsync(x => x.Id == id && x.IsDeleted == false && x.Language.IsDeleted == false);
        }
    }
}

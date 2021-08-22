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
    public class EFOrderContentDal : EFRepositoryBase<OrderContent, AppDbContext>, IOrderContentDal
    {
        public async Task<OrderContent> GetOrderContentAsync(string languageCode)
        {
            await using var context = new AppDbContext();
            return await context.OrderContents.Include(x => x.Language)
                .FirstOrDefaultAsync(x => x.Language.IsDeleted == false && x.Language.Code == languageCode);
        }
    }
}

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
    public class EFHowItWorkCardDal : EFRepositoryBase<HowItWorkCard, AppDbContext>, IHowItWorkCardDal
    {
        public async Task<List<HowItWorkCard>> GetAllMultiLanguageHowItWorkCardsAsync(string languageCode)
        {
            await using var context = new AppDbContext();
            return await context.HowItWorkCards.Include(x => x.Language)
                .Where(x => x.Language.Code == languageCode && x.Language.IsDeleted == false && x.IsDeleted == false).ToListAsync();
        }

        public async Task<List<HowItWorkCard>> GetHowItWorkCardsByCountAsync(int skipCount, int takeCount)
        {
            await using var context = new AppDbContext();
            return await context.HowItWorkCards.Where(x => x.IsDeleted == false)
                .OrderByDescending(x => x.Id).Skip(skipCount).Take(takeCount).ToListAsync();
        }

        public async Task<HowItWorkCard> GetHowItWorkCardWithIncludeAsync(int id)
        {
            await using var context = new AppDbContext();
            return await context.HowItWorkCards.Include(x => x.Language)
                .FirstOrDefaultAsync(x => x.Id == id && x.IsDeleted == false && x.Language.IsDeleted == false);
        }
    }
}

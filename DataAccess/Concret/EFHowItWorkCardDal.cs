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
        public EFHowItWorkCardDal(AppDbContext context) : base(context)
        {
        }

        public async Task<List<HowItWorkCard>> GetAllMultiLanguageHowItWorkCardsAsync(string languageCode)
        {
            return await Context.HowItWorkCards.Include(x => x.Language)
                .Where(x => x.Language.Code == languageCode && x.Language.IsDeleted == false && x.IsDeleted == false).ToListAsync();
        }

        public async Task<List<HowItWorkCard>> GetHowItWorkCardsByCountAsync(int skipCount, int takeCount)
        {
            return await Context.HowItWorkCards.Where(x => x.IsDeleted == false)
                .OrderByDescending(x => x.Id).Skip(skipCount).Take(takeCount).ToListAsync();
        }

        public async Task<HowItWorkCard> GetHowItWorkCardWithIncludeAsync(int id)
        {
            return await Context.HowItWorkCards.Include(x => x.Language)
                .FirstOrDefaultAsync(x => x.Id == id && x.IsDeleted == false && x.Language.IsDeleted == false);
        }
    }
}

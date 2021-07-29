using Buisness.Abstract;
using DataAccess.Abstract;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Buisness.Concret
{
    public class HowItWorkCardManager : IHowItWorkCardService
    {
        private readonly IHowItWorkCardDal _howItWorkCardDal;

        public HowItWorkCardManager(IHowItWorkCardDal howItWorkCardDal)
        {
            _howItWorkCardDal = howItWorkCardDal;
        }

        public async Task<bool> AddAsync(HowItWorkCard howItWorkCard)
        {
            await _howItWorkCardDal.AddAsync(howItWorkCard);

            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            await _howItWorkCardDal.DeleteAsync(new HowItWorkCard { Id = id });

            return true;
        }

        public async Task<List<HowItWorkCard>> GetAllHowItWorkCardsAsync()
        {
            return await _howItWorkCardDal.GetAllAsync(x => x.IsDeleted == false);
        }

        public async Task<List<HowItWorkCard>> GetAllHowItWorkCardsAsync(string languageCode)
        {
            return await _howItWorkCardDal.GetAllMultiLanguageHowItWorkCardsAsync(languageCode);
        }

        public async Task<List<HowItWorkCard>> GetAllHowItWorkCardsAsync(int skipCount, int takeCount)
        {
            return await _howItWorkCardDal.GetHowItWorkCardsByCountAsync(skipCount, takeCount);
        }

        public async Task<HowItWorkCard> GetHowItWorkCardAsync(int id)
        {
            return await _howItWorkCardDal.GetAsync(x => x.Id == id && x.IsDeleted == false);
        }

        public async Task<HowItWorkCard> GetHowItWorkCardWithLanguageAsync(int id)
        {
            return await _howItWorkCardDal.GetHowItWorkCardWithIncludeAsync(id);
        }

        public async Task<bool> UpdateAsync(HowItWorkCard howItWorkCard)
        {
            await _howItWorkCardDal.UpdateAsync(howItWorkCard);

            return true;
        }
    }
}

using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Buisness.Abstract
{
    public interface IHowItWorkCardService
    {
        Task<HowItWorkCard> GetHowItWorkCardAsync(int id);

        Task<HowItWorkCard> GetHowItWorkCardWithLanguageAsync(int id);

        Task<List<HowItWorkCard>> GetAllHowItWorkCardsAsync();

        Task<List<HowItWorkCard>> GetAllHowItWorkCardsAsync(string languageCode);

        Task<List<HowItWorkCard>> GetAllHowItWorkCardsAsync(int skipCount,int takeCount);

        Task<bool> AddAsync(HowItWorkCard howItWorkCard);

        Task<bool> UpdateAsync(HowItWorkCard howItWorkCard);

        Task<bool> DeleteAsync(int id);
    }
}

using Core.Repository;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IHowItWorkCardDal : IRepository<HowItWorkCard>
    {
        Task<HowItWorkCard> GetHowItWorkCardWithIncludeAsync(int id);

        Task<List<HowItWorkCard>> GetAllMultiLanguageHowItWorkCardsAsync(string languageCode);

        Task<List<HowItWorkCard>> GetHowItWorkCardsByCountAsync(int skipCount, int takeCount);
    }
}

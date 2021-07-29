using Buisness.Abstract;
using DataAccess.Abstract;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Buisness.Concret
{
    public class AdvertisementTitleManger : IAdvertisementTitleService
    {
        private readonly IAdvertisementTitleDal _advertisementTitleDal;

        public AdvertisementTitleManger(IAdvertisementTitleDal advertisementTitleDal)
        {
            _advertisementTitleDal = advertisementTitleDal;
        }

        public async Task<bool> AddAsync(AdvertisimentTitle advertisementTitle)
        {
            await _advertisementTitleDal.AddAsync(advertisementTitle);

            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            await _advertisementTitleDal.DeleteAsync(new AdvertisimentTitle { Id = id });

            return true;
        }

        public async Task<AdvertisimentTitle> GetAdvertisementTitleAsync(int id)
        {
            return await _advertisementTitleDal.GetAsync(x => x.Id == id && x.IsDeleted == false);
        }

        public async Task<AdvertisimentTitle> GetAdvertisementTitleAsync(string languageCode)
        {
            return await _advertisementTitleDal.GetMultiLanguageAdvertisementTitleAsync(languageCode);
        }

        public async Task<List<AdvertisimentTitle>> GetAllAdvertisementTitlesAsync()
        {
            return await _advertisementTitleDal.GetAllAsync(x => x.IsDeleted == false);
        }

        public async Task<List<AdvertisimentTitle>> GetAllAdvertisementTitlesAsync(int skipCount, int takeCount)
        {
            return await _advertisementTitleDal.GetAllAdvertisementTitlesByCountAsync(skipCount, takeCount);
        }

        public async Task<bool> UpdateAsync(AdvertisimentTitle advertisementTitle)
        {
            await _advertisementTitleDal.UpdateAsync(advertisementTitle);

            return true;
        }
    }
}

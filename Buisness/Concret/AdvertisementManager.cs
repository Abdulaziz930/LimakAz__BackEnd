using Buisness.Abstract;
using DataAccess.Abstract;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Buisness.Concret
{
    public class AdvertisementManager : IAdvertisementService
    {
        private readonly IAdvertisementDal _advertisementDal;

        public AdvertisementManager(IAdvertisementDal advertisementDal)
        {
            _advertisementDal = advertisementDal;
        }

        public async Task<bool> AddAsync(Advertisement advertisement)
        {
            await _advertisementDal.AddAsync(advertisement);

            return true;
        }

        public async Task<bool> AddAsync(Advertisement advertisement, AdvertisementDetail advertisementDetail)
        {
            return await _advertisementDal.AddRangeAsync(advertisement, advertisementDetail);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            await _advertisementDal.DeleteAsync(new Advertisement { Id = id });

            return true;
        }

        public async Task<Advertisement> GetAdvertisementAsync(int id)
        {
            return await _advertisementDal.GetAsync(x => x.Id == id && x.IsDeleted == false);
        }

        public async Task<Advertisement> GetAdvertisementAsync(int id,string langaugeCode)
        {
            return await _advertisementDal.GetMultiLanguageAdvertisementAsync(id, langaugeCode);
        }

        public async Task<Advertisement> GetAdvertisementWithDetailAndLanaguageAsync(int id)
        {
            return await _advertisementDal.GetAdvertisementWithIncludes(id);
        }

        public async Task<Advertisement> GetAdvertisementWithDetailAsync(int id)
        {
            return await _advertisementDal.GetAdvertisementWithInclude(id);
        }

        public async Task<List<Advertisement>> GetAllAdvertisementsAsync()
        {
            return await _advertisementDal.GetAllAsync(x => x.IsDeleted == false);
        }

        public async Task<List<Advertisement>> GetAllAdvertisementsAsync(string lagaugeCode)
        {
            return await _advertisementDal.GetAllMultiLanguageAdvertisementAsync(lagaugeCode);
        }

        public async Task<List<Advertisement>> GetAllAdvertisementsAsync(int skipCount, int takeCount)
        {
            return await _advertisementDal.GetAdvertisementByCountAsync(skipCount, takeCount);
        }

        public async Task<List<Advertisement>> GetAllAdvertisementsAsync(int takeCount,string languageCode)
        {
            return await _advertisementDal.GetAdvertisementByCountAsync(takeCount,languageCode);
        }

        public async Task<bool> UpdateAsync(Advertisement advertisement)
        {
            await _advertisementDal.UpdateAsync(advertisement);

            return true;
        }
    }
}

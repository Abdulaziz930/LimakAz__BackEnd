using Buisness.Abstract;
using DataAccess.Abstract;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Buisness.Concret
{
    public class AdvertisementHeaderManager : IAdvertisementHeaderService
    {
        private readonly IAdvertisementHeaderDal _advertisementHeaderDal;

        public AdvertisementHeaderManager(IAdvertisementHeaderDal advertisementHeaderDal)
        {
            _advertisementHeaderDal = advertisementHeaderDal;
        }

        public async Task<bool> AddAsync(AdvertisementHeader advertisementHeader)
        {
            await _advertisementHeaderDal.AddAsync(advertisementHeader);

            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            await _advertisementHeaderDal.DeleteAsync(new AdvertisementHeader { Id = id });

            return true;
        }

        public async Task<AdvertisementHeader> GetAdvertisementHeaderAsync(int id)
        {
            return await _advertisementHeaderDal.GetAsync(x => x.Id == id && x.IsDeleted == false);
        }

        public async Task<AdvertisementHeader> GetAdvertisementHeaderAsync(string languageCode)
        {
            return await _advertisementHeaderDal.GetAdvertisementHeaderAsync(languageCode);
        }

        public async Task<List<AdvertisementHeader>> GetAllAdvertisementHeadersAsync()
        {
            return await _advertisementHeaderDal.GetAllAsync(x => x.IsDeleted == false);
        }

        public async Task<List<AdvertisementHeader>> GetAllAdvertisementHeadersAsync(int skipCount, int takeCount)
        {
            return await _advertisementHeaderDal.GetAdvertisementHeadersByCountAsync(skipCount, takeCount);
        }

        public async Task<bool> UpdateAsync(AdvertisementHeader advertisementHeader)
        {
            await _advertisementHeaderDal.UpdateAsync(advertisementHeader);

            return true;
        }
    }
}

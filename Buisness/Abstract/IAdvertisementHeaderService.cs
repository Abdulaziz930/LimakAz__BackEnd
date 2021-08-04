using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Buisness.Abstract
{
    public interface IAdvertisementHeaderService
    {
        Task<AdvertisementHeader> GetAdvertisementHeaderAsync(int id);

        Task<AdvertisementHeader> GetAdvertisementHeaderAsync(string languageCode);

        Task<List<AdvertisementHeader>> GetAllAdvertisementHeadersAsync();

        Task<List<AdvertisementHeader>> GetAllAdvertisementHeadersAsync(int skipCount, int takeCount);

        Task<bool> AddAsync(AdvertisementHeader advertisementHeader);

        Task<bool> UpdateAsync(AdvertisementHeader advertisementHeader);

        Task<bool> DeleteAsync(int id);
    }
}

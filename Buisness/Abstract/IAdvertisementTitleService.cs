using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Buisness.Abstract
{
    public interface IAdvertisementTitleService
    {
        Task<AdvertisimentTitle> GetAdvertisementTitleAsync(int id);

        Task<AdvertisimentTitle> GetAdvertisementTitleAsync(string languageCode);

        Task<List<AdvertisimentTitle>> GetAllAdvertisementTitlesAsync();

        Task<List<AdvertisimentTitle>> GetAllAdvertisementTitlesAsync(int skipCount,int takeCount);

        Task<bool> AddAsync(AdvertisimentTitle advertisementTitle);

        Task<bool> UpdateAsync(AdvertisimentTitle advertisementTitle);

        Task<bool> DeleteAsync(int id);
    }
}

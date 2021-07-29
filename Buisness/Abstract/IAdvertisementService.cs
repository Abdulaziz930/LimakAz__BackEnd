using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Buisness.Abstract
{
    public interface IAdvertisementService
    {
        Task<Advertisement> GetAdvertisementAsync(int id);

        Task<Advertisement> GetAdvertisementWithDetailAsync(int id);

        Task<Advertisement> GetAdvertisementWithDetailAndLanaguageAsync(int id);

        Task<List<Advertisement>> GetAllAdvertisementsAsync();

        Task<List<Advertisement>> GetAllAdvertisementsAsync(string langaugeCode);

        Task<List<Advertisement>> GetAllAdvertisementsAsync(int skipCount,int takeCount);

        Task<List<Advertisement>> GetAllAdvertisementsAsync(int takeCount,string langaugeCode);

        Task<bool> AddAsync(Advertisement advertisement);

        Task<bool> AddAsync(Advertisement advertisement,AdvertisementDetail advertisementDetail);

        Task<bool> UpdateAsync(Advertisement advertisement);

        Task<bool> DeleteAsync(int id);
    }
}

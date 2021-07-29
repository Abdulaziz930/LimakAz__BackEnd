using Core.Repository;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IAdvertisementDal : IRepository<Advertisement>
    {
        Task<Advertisement> GetAdvertisementWithInclude(int id);

        Task<Advertisement> GetAdvertisementWithIncludes(int id);

        Task<Advertisement> GetMultiLanguageAdvertisementAsync(int id, string languageCode);

        Task<List<Advertisement>> GetAllMultiLanguageAdvertisementAsync(string languageCode);

        Task<List<Advertisement>> GetAdvertisementByCountAsync(int skipCount,int takeCount);

        Task<List<Advertisement>> GetAdvertisementByCountAsync(int takeCount,string languageCode);

        Task<bool> AddRangeAsync(Advertisement advertisement, AdvertisementDetail advertisementDetail);
    }
}

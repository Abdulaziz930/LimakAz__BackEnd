using Core.Repository;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IAdvertisementHeaderDal : IRepository<AdvertisementHeader>
    {
        Task<AdvertisementHeader> GetAdvertisementHeaderAsync(string languageCode);

        Task<List<AdvertisementHeader>> GetAdvertisementHeadersByCountAsync(int skipCount, int takeCount);
    }
}

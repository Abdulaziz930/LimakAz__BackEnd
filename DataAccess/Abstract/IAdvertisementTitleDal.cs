using Core.Repository;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IAdvertisementTitleDal : IRepository<AdvertisimentTitle>
    {
        Task<AdvertisimentTitle> GetMultiLanguageAdvertisementTitleAsync(string languageCode);

        Task<List<AdvertisimentTitle>> GetAllAdvertisementTitlesByCountAsync(int skipCount, int takeCount);
    }
}

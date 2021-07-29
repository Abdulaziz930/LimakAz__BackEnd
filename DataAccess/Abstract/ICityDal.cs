using Core.Repository;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface ICityDal : IRepository<City>
    {
        Task<City> GetCityWithIncludeAsync(int id);

        Task<City> GetMultiLanguageCityAsync(int id, string languageCode);

        Task<List<City>> GetAllMultiLanguageCitiesAsync(string languageCode);

        Task<List<City>> GetCitiesByCountAsync(int skipCount, int takeCount);
    }
}

using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Buisness.Abstract
{
    public interface ICityService
    {
        Task<City> GetCityAsync(int id);

        Task<City> GetCityWithLanguageAsync(int id);

        Task<City> GetCityAsync(int id,string languageCode);

        Task<List<City>> GetAllCitiesAsync();

        Task<List<City>> GetAllCitiesAsync(string languageCode);

        Task<List<City>> GetAllCitiesAsync(int skipCount,int takeCount);

        Task<bool> AddAsync(City city);

        Task<bool> UpdateAsync(City city);

        Task<bool> DeleteAsync(int id);
    }
}

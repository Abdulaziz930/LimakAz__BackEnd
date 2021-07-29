using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Buisness.Abstract
{
    public interface ICountryService
    {
        Task<Country> GetCountryAsync(int id);

        Task<Country> GetCountryWithLanguageAsync(int id);

        Task<Country> GetCountryAsync(int id,string languageCode);

        Task<List<Country>> GetAllCountriesAsync();

        Task<List<Country>> GetAllCountriesAsync(string languageCode);

        Task<List<Country>> GetAllCountriesAsync(int takeCount,int skipCount);

        Task<bool> AddAsync(Country country);

        Task<bool> UpdateAsync(Country country);

        Task<bool> DeleteAsync(int id);
    }
}

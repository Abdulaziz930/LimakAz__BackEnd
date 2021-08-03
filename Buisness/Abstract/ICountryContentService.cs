using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Buisness.Abstract
{
    public interface ICountryContentService
    {
        Task<CountryContent> GetCountryContentAsync(int id);

        Task<CountryContent> GetCountryContentAsync(string languageCode);

        Task<List<CountryContent>> GetAllCountryContentsAsync();

        Task<List<CountryContent>> GetAllCountryContentsAsync(int skipCount, int takeCount);

        Task<bool> AddAsync(CountryContent countryContent);

        Task<bool> UpdateAsync(CountryContent countryContent);

        Task<bool> DeleteAsync(int id);
    }
}

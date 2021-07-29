using Buisness.Abstract;
using DataAccess.Abstract;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Buisness.Concret
{
    public class CountryManager : ICountryService
    {
        private readonly ICountryDal _countryDal;

        public CountryManager(ICountryDal countryDal)
        {
            _countryDal = countryDal;
        }

        public async Task<bool> AddAsync(Country country)
        {
            await _countryDal.AddAsync(country);

            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            await _countryDal.DeleteAsync(new Country { Id = id });

            return true;
        }

        public async Task<List<Country>> GetAllCountriesAsync()
        {
            return await _countryDal.GetAllAsync(x => x.IsDeleted == false);
        }

        public async Task<List<Country>> GetAllCountriesAsync(string languageCode)
        {
            return await _countryDal.GetAllMultiLanguageCountriesAsync(languageCode);
        }

        public async Task<List<Country>> GetAllCountriesAsync(int skipCount, int takeCount)
        {
            return await _countryDal.GetCountriesByCountAsync(skipCount, takeCount);
        }

        public async Task<Country> GetCountryAsync(int id)
        {
            return await _countryDal.GetAsync(x => x.Id == id && x.IsDeleted == false);
        }

        public async Task<Country> GetCountryAsync(int id,string languageCode)
        {
            return await _countryDal.GetMultiLanguageCountryAsync(id, languageCode);
        }

        public async Task<Country> GetCountryWithLanguageAsync(int id)
        {
            return await _countryDal.GetCountryWithIncludeAsync(id);
        }

        public async Task<bool> UpdateAsync(Country country)
        {
            await _countryDal.UpdateAsync(country);

            return true;
        }
    }
}

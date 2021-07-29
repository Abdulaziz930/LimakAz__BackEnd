using Buisness.Abstract;
using DataAccess.Abstract;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Buisness.Concret
{
    public class CityManager : ICityService
    {
        private readonly ICityDal _cityDal;

        public CityManager(ICityDal cityDal)
        {
            _cityDal = cityDal;
        }

        public async Task<bool> AddAsync(City city)
        {
            await _cityDal.AddAsync(city);

            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            await _cityDal.DeleteAsync(new City { Id = id });

            return true;
        }

        public async Task<List<City>> GetAllCitiesAsync()
        {
            return await _cityDal.GetAllAsync(x => x.IsDeleted == false);
        }

        public async Task<List<City>> GetAllCitiesAsync(string languageCode)
        {
            return await _cityDal.GetAllMultiLanguageCitiesAsync(languageCode);
        }

        public async Task<List<City>> GetAllCitiesAsync(int skipCount, int takeCount)
        {
            return await _cityDal.GetCitiesByCountAsync(skipCount, takeCount);
        }

        public async Task<City> GetCityAsync(int id)
        {
            return await _cityDal.GetAsync(x => x.Id == id && x.IsDeleted == false);
        }

        public async Task<City> GetCityAsync(int id,string languageCode)
        {
            return await _cityDal.GetMultiLanguageCityAsync(id, languageCode);
        }

        public async Task<City> GetCityWithLanguageAsync(int id)
        {
            return await _cityDal.GetCityWithIncludeAsync(id);
        }

        public async Task<bool> UpdateAsync(City city)
        {
            await _cityDal.UpdateAsync(city);

            return true;
        }
    }
}

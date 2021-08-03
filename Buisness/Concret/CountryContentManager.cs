using Buisness.Abstract;
using DataAccess.Abstract;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Buisness.Concret
{
    public class CountryContentManager : ICountryContentService
    {
        private readonly ICountryContentDal _countryContentDal;

        public CountryContentManager(ICountryContentDal countryContentDal)
        {
            _countryContentDal = countryContentDal;
        }

        public async Task<bool> AddAsync(CountryContent countryContent)
        {
            await _countryContentDal.AddAsync(countryContent);

            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            await _countryContentDal.DeleteAsync(new CountryContent { Id = id });

            return true;
        }

        public async Task<List<CountryContent>> GetAllCountryContentsAsync()
        {
            return await _countryContentDal.GetAllAsync(x => x.IsDeleted == false);
        }

        public async Task<List<CountryContent>> GetAllCountryContentsAsync(int skipCount, int takeCount)
        {
            return await _countryContentDal.GetCountryContentsByCountAsync(skipCount, takeCount);
        }

        public async Task<CountryContent> GetCountryContentAsync(int id)
        {
            return await _countryContentDal.GetAsync(x => x.Id == id);
        }

        public async Task<CountryContent> GetCountryContentAsync(string languageCode)
        {
            return await _countryContentDal.GetCountryContentAsync(languageCode);
        }

        public async Task<bool> UpdateAsync(CountryContent countryContent)
        {
            await _countryContentDal.UpdateAsync(countryContent);

            return true;
        }
    }
}

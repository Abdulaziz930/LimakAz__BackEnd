using Buisness.Abstract;
using DataAccess.Abstract;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Buisness.Concret
{
    public class TariffManager : ITariffService
    {
        private readonly ITariffDal _tariffDal;

        public TariffManager(ITariffDal tariffDal)
        {
            _tariffDal = tariffDal;
        }

        public async Task<bool> AddAsync(Tariff tariff)
        {
            await _tariffDal.AddAsync(tariff);

            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            await _tariffDal.DeleteAsync(new Tariff { Id = id });

            return true;
        }

        public async Task<List<Tariff>> GetAllTariffContentsAsync()
        {
            return await _tariffDal.GetAllAsync();
        }

        public async Task<List<CountryProductType>> GetMultiLanguageTrariffsAsync(string languageCode)
        {
            return await _tariffDal.GetMultiLanguageTrariffsWithIncludesAsync(languageCode);
        }

        public async Task<Tariff> GetTariffAsync(int id)
        {
            return await _tariffDal.GetAsync(x => x.Id == id);
        }

        public async Task<bool> UpdateAsync(Tariff tariff)
        {
            await _tariffDal.UpdateAsync(tariff);

            return true;
        }
    }
}

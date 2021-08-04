using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Buisness.Abstract
{
    public interface ITariffService
    {
        Task<Tariff> GetTariffAsync(int id);

        Task<List<Tariff>> GetAllTariffContentsAsync();

        Task<List<Tariff>> GetAllTariffContentsAsync(int productTypeId, int countryId);

        Task<bool> AddAsync(Tariff tariff);

        Task<bool> UpdateAsync(Tariff tariff);

        Task<bool> DeleteAsync(int id);

        Task<List<Country>> GetMultiLanguageTrariffsAsync(string languageCode);
    }
}

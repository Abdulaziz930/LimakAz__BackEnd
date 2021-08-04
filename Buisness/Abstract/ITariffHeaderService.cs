using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Buisness.Abstract
{
    public interface ITariffHeaderService
    {
        Task<TariffHeader> GetTariffHeaderAsync(int id);

        Task<TariffHeader> GetTariffHeaderAsync(string languageCode);

        Task<List<TariffHeader>> GetAllTariffHeadersAsync();

        Task<List<TariffHeader>> GetAllTariffHeadersAsync(int skipCount, int takeCount);

        Task<bool> AddAsync(TariffHeader tariffHeader);

        Task<bool> UpdateAsync(TariffHeader tariffHeader);

        Task<bool> DeleteAsync(int id);
    }
}

using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Buisness.Abstract
{
    public interface IRegisterInformationService
    {
        Task<RegisterInformation> GetRegisterInformationAsync(int id);

        Task<RegisterInformation> GetRegisterInformationAsync(string languageCode);

        Task<List<RegisterInformation>> GetAllRegisterInformationsAsync();

        Task<List<RegisterInformation>> GetAllRegisterInformationsAsync(int skipCount, int takeCount);

        Task<bool> AddAsync(RegisterInformation registerInformation);

        Task<bool> UpdateAsync(RegisterInformation registerInformation);

        Task<bool> DeleteAsync(int id);
    }
}

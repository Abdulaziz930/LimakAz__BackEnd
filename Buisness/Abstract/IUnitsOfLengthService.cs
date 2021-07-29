using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Buisness.Abstract
{
    public interface IUnitsOfLengthService
    {
        Task<UnitsOfLength> GetUnitsOfLengthAsync(int id);

        Task<UnitsOfLength> GetUnitsOfLengthWithLanguageAsync(int id);

        Task<List<UnitsOfLength>> GetAllUnitsOfLengthAsync();

        Task<List<UnitsOfLength>> GetAllUnitsOfLengthAsync(string languageCode);

        Task<List<UnitsOfLength>> GetAllUnitsOfLengthAsync(int skipCount,int takeCount);

        Task<bool> AddAsync(UnitsOfLength unitsOfLength);

        Task<bool> UpdateAsync(UnitsOfLength unitsOfLength);

        Task<bool> DeleteAsync(int id);
    }
}

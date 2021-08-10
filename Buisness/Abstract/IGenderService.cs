using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Buisness.Abstract
{
    public interface IGenderService
    {
        Task<Gender> GetGenderAsync(int id);

        Task<List<Gender>> GetAllGendersAsync(string languageCode);

        Task<List<Gender>> GetAllGendersAsync();

        Task<List<Gender>> GetAllGendersAsync(int skipCount, int takeCount);

        Task<bool> AddAsync(Gender gender);

        Task<bool> UpdateAsync(Gender gender);

        Task<bool> DeleteAsync(int id);
    }
}

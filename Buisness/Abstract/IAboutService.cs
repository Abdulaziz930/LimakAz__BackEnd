using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Buisness.Abstract
{
    public interface IAboutService
    {
        Task<About> GetAboutAsync(int id);

        Task<About> GetAboutWithLanguageAsync(int id);

        Task<About> GetAboutAsync(string languageCode);

        Task<List<About>> GetAllAboutsAsync();

        Task<List<About>> GetAllAboutsAsync(int skipCount, int takeCount);

        Task<bool> AddAsync(About about);

        Task<bool> UpdateAsync(About about);

        Task<bool> DeleteAsync(int id);
    }
}

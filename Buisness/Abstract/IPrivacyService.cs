using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Buisness.Abstract
{
    public interface IPrivacyService
    {
        Task<Privacy> GetPrivacyAsync(int id);

        Task<Privacy> GetPrivacyWithLanguageAsync(int id);

        Task<Privacy> GetPrivacyAsync(string languageCode);

        Task<List<Privacy>> GetAllPrivaciesAsync();

        Task<List<Privacy>> GetAllPrivaciesAsync(int skipCount, int takeCount);

        Task<bool> AddAsync(Privacy privacy);

        Task<bool> UpdateAsync(Privacy privacy);

        Task<bool> DeleteAsync(int id);
    }
}

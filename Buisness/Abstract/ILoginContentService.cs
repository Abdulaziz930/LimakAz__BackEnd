using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Buisness.Abstract
{
    public interface ILoginContentService
    {
        Task<LoginContent> GetLoginContentAsync(int id);

        Task<LoginContent> GetLoginContentAsync(string languageCode);

        Task<List<LoginContent>> GetAllLoginContentsAsync();

        Task<List<LoginContent>> GetAllLoginContentsAsync(int skipCount, int takeCount);

        Task<bool> AddAsync(LoginContent loginContent);

        Task<bool> UpdateAsync(LoginContent loginContent);

        Task<bool> DeleteAsync(int id);
    }
}

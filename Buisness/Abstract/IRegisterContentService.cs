using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Buisness.Abstract
{
    public interface IRegisterContentService
    {
        Task<RegisterContent> GetRegisterContentAsync(int id);

        Task<RegisterContent> GetRegisterContentWithLanguageAsync(int id);

        Task<RegisterContent> GetRegisterContentAsync(string langaugeCode);

        Task<List<RegisterContent>> GetAllRegisterContentsAsync();


        Task<List<RegisterContent>> GetAllRegisterContentsAsync(int skipCount, int takeCount);

        Task<bool> AddAsync(RegisterContent registerContent);

        Task<bool> UpdateAsync(RegisterContent registerContent);

        Task<bool> DeleteAsync(int id);
    }
}

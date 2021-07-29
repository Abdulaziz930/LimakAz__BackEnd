using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Buisness.Abstract
{
    public interface IHowItWorkService
    {
        Task<HowItWork> GetHowItWorkAsync(int id);

        Task<HowItWork> GetHowItWorkWithLanguageAsync(int id); 

        Task<HowItWork> GetHowItWorkAsync(string languageCode);

        Task<List<HowItWork>> GetAllHowItWorksAsync();

        Task<List<HowItWork>> GetAllHowItWorksAsync(int skipCount,int takeCount);

        Task<bool> AddAsync(HowItWork howItWork);

        Task<bool> UpdateAsync(HowItWork howItWork);

        Task<bool> DeleteAsync(int id);
    }
}

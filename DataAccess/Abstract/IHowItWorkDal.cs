using Core.Repository;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IHowItWorkDal : IRepository<HowItWork>
    {
        Task<HowItWork> GetHowItWorkWithIncludeAsync(int id);

        Task<HowItWork> GetMultiLanguageHowItWorkAsync(string languageCode);

        Task<List<HowItWork>> GetHowItWorksByCountAsync(int skipCount, int takeCount);
    }
}

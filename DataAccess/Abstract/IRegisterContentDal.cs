using Core.Repository;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IRegisterContentDal : IRepository<RegisterContent>
    {
        Task<RegisterContent> GetRegisterContentWithInclude(int id);

        Task<RegisterContent> GetMultiLanguageRegisterContentAsync(string languageCode);

        Task<List<RegisterContent>> GetRegisterContentsByCountAsync(int skipCount, int takeCount);
    }
}

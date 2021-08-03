using Core.Repository;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IPrivacyDal : IRepository<Privacy>
    {
        Task<Privacy> GetPrivacyAsync(string languageCode);

        Task<Privacy> GetPrivacyWithInclude(int id);

        Task<List<Privacy>> GetPrivaciesByCountAsync(int skipCount, int takeCount);
    }
}

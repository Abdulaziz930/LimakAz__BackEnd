using Core.Repository;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IAboutDal : IRepository<About>
    {
        Task<About> GetAboutAsync(string languageCode);

        Task<About> GetAboutWithInclude(int id);

        Task<List<About>> GetAboutsByCountAsync(int skipCount, int takeCount);
    }
}

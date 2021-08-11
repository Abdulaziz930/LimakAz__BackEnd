using Core.Repository;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface ILoginContentDal : IRepository<LoginContent>
    {
        Task<LoginContent> GetLoginContentAsync(string languageCode);

        Task<List<LoginContent>> GetLoginContentsByCountAsync(int skipCount, int takeCount);
    }
}

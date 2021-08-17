using Core.Repository;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IBalanceContentDal : IRepository<BalanceContent>
    {
        Task<BalanceContent> GetBalanceContentAsync(string languageCode);

        Task<List<BalanceContent>> GetBalanceContentsByCountAsync(int skipCount, int takeCount);
    }
}

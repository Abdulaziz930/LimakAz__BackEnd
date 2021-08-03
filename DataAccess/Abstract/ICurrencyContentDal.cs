using Core.Repository;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface ICurrencyContentDal : IRepository<CurrencyContent>
    {
        Task<List<CurrencyContent>> GetCurrencyContentsByCountAsync(int skipCount, int takeCount);
    }
}

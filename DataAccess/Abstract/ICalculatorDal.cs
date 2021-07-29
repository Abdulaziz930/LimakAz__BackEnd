using Core.Repository;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface ICalculatorDal : IRepository<Calculator>
    {
        Task<Calculator> GetMultiLanguageCalculatorAsync(string languageCode);

        Task<Calculator> GetCalculatorWithIncludeAsync(int id);

        Task<List<Calculator>> GetAllCalculatorContentsByCountAsync(int skipCount, int takeCount);
    }
}

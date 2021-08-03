using Core.Repository;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface ICalculatorContentDal : IRepository<CalculatorContent>
    {
        Task<CalculatorContent> GetCalculatorContentAsync(string languageCode);

        Task<List<CalculatorContent>> GetCalculatorContentsByCountAsync(int skipCount, int takeCount);
    }
}

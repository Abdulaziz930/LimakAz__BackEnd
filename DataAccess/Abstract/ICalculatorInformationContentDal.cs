using Core.Repository;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface ICalculatorInformationContentDal : IRepository<CalculatorIntormationContent>
    {
        Task<List<CalculatorIntormationContent>> GetCalculatorIntormationContentsAsync(string languageCode);

        Task<List<CalculatorIntormationContent>> GetCalculatorIntormationContentsByCountAsync(int skipCount, int takeCount);
    }
}

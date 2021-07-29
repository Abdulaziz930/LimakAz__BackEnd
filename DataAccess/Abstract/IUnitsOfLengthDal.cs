using Core.Repository;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IUnitsOfLengthDal : IRepository<UnitsOfLength>
    {
        Task<UnitsOfLength> GetUnitsOfLengthWithIncludeAsync(int id);

        Task<List<UnitsOfLength>> GetAllMultiLanguageUnitsOfLengthAsync(string languageCode);

        Task<List<UnitsOfLength>> GetUnitsOfLengthByCountAsync(int skipCount, int takeCount);
    }
}

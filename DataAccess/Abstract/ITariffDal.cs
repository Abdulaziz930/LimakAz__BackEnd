using Core.Repository;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface ITariffDal : IRepository<Tariff>
    {
        Task<List<CountryProductType>> GetMultiLanguageTrariffsWithIncludesAsync(string languageCode);
    }
}

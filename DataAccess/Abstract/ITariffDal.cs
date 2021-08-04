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
        Task<List<Country>> GetMultiLanguageTrariffsWithIncludesAsync(string languageCode);

        //Task<List<ProductType>> GetMultiLanguageTrariffsAsync(string languageCode);

        Task<List<Tariff>> GetTrariffsWithIncludeAsync(int productTypeId,int countryId);
    }
}

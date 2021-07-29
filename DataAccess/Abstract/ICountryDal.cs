using Core.Repository;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface ICountryDal : IRepository<Country>
    {
        Task<Country> GetCountryWithIncludeAsync(int id);

        Task<Country> GetMultiLanguageCountryAsync(int id, string languageCode);

        Task<List<Country>> GetAllMultiLanguageCountriesAsync(string languageCode);

        Task<List<Country>> GetCountriesByCountAsync(int skipCount, int takeCount);
    }
}

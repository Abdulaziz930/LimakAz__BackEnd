using Core.Repository;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface ICountryContentDal : IRepository<CountryContent>
    {
        Task<CountryContent> GetCountryContentAsync(string languageCode);

        Task<List<CountryContent>> GetCountryContentsByCountAsync(int skipCount, int takeCount);
    }
}

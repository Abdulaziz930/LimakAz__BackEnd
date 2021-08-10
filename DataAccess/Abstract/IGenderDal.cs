using Core.Repository;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IGenderDal : IRepository<Gender>
    {
        Task<List<Gender>> GetMultiLanguageGendersAsync(string languageCode);

        Task<List<Gender>> GetGendersByCountAsync(int skipCount, int takeCount);
    }
}

using Core.Repository;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface ILangaugeDal : IRepository<Language>
    {
        Task<List<Language>> GetLanguagesByCountAsync(int skipCount, int takeCount);

        Task<bool> CheckLanguagesAsync(Expression<Func<Language, bool>> filter);
    }
}

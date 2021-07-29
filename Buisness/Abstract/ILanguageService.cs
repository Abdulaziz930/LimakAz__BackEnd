using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Buisness.Abstract
{
    public interface ILanguageService
    {
        Task<Language> GetLanguageAsync(int id);

        Task<List<Language>> GetAllLanguagesAsync(Expression<Func<Language,bool>> filter = null);

        Task<List<Language>> GetAllLanguagesAsync(int skipCount, int takeCount);

        Task<bool> LanguagesAnyAsync(Expression<Func<Language, bool>> filter);

        Task<bool> AddAsync(Language language);

        Task<bool> UpdateAsync(Language language);

        Task<bool> DeleteAsync(int id);
    }
}

using Buisness.Abstract;
using DataAccess.Abstract;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Buisness.Concret
{
    public class LanguageManager : ILanguageService
    {
        private readonly ILangaugeDal _languageDal;

        public LanguageManager(ILangaugeDal langaugeDal)
        {
            _languageDal = langaugeDal;
        }

        public async Task<bool> AddAsync(Language language)
        {
            await _languageDal.AddAsync(language);

            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            await _languageDal.DeleteAsync(new Language { Id = id });

            return true;
        }

        public async Task<List<Language>> GetAllLanguagesAsync(Expression<Func<Language,bool>> filter)
        {
            return await _languageDal.GetAllAsync(filter);
        }

        public async Task<List<Language>> GetAllLanguagesAsync(int skipCount, int takeCount)
        {
            return await _languageDal.GetLanguagesByCountAsync(skipCount, takeCount);
        }

        public async Task<Language> GetLanguageAsync(int id)
        {
            return await _languageDal.GetAsync(x => x.Id == id && x.IsDeleted == false);
        }

        public async Task<bool> LanguagesAnyAsync(Expression<Func<Language, bool>> filter)
        {
            return await _languageDal.CheckLanguagesAsync(filter);
        }

        public async Task<bool> UpdateAsync(Language language)
        {
            await _languageDal.UpdateAsync(language);

            return true;
        }
    }
}

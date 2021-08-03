using Buisness.Abstract;
using DataAccess.Abstract;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Buisness.Concret
{
    public class PrivacyManager : IPrivacyService
    {
        private readonly IPrivacyDal _privacyDal;

        public PrivacyManager(IPrivacyDal privacyDal)
        {
            _privacyDal = privacyDal;
        }

        public async Task<bool> AddAsync(Privacy privacy)
        {
            await _privacyDal.AddAsync(privacy);

            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            await _privacyDal.DeleteAsync(new Privacy { Id = id });

            return true;
        }

        public async Task<List<Privacy>> GetAllPrivaciesAsync()
        {
            return await _privacyDal.GetAllAsync(x => x.IsDeleted == false);
        }

        public async Task<List<Privacy>> GetAllPrivaciesAsync(int skipCount, int takeCount)
        {
            return await _privacyDal.GetPrivaciesByCountAsync(skipCount, takeCount);
        }

        public async Task<Privacy> GetPrivacyAsync(int id)
        {
            return await _privacyDal.GetAsync(x => x.Id == id && x.IsDeleted == false);
        }

        public async Task<Privacy> GetPrivacyAsync(string languageCode)
        {
            return await _privacyDal.GetPrivacyAsync(languageCode);
        }

        public async Task<Privacy> GetPrivacyWithLanguageAsync(int id)
        {
            return await _privacyDal.GetPrivacyWithInclude(id);
        }

        public async Task<bool> UpdateAsync(Privacy privacy)
        {
            await _privacyDal.UpdateAsync(privacy);

            return true;
        }
    }
}

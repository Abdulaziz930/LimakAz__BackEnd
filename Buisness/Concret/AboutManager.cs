using Buisness.Abstract;
using DataAccess.Abstract;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Buisness.Concret
{
    public class AboutManager : IAboutService
    {
        private readonly IAboutDal _aboutDal;

        public AboutManager(IAboutDal aboutDal)
        {
            _aboutDal = aboutDal;
        }

        public async Task<bool> AddAsync(About about)
        {
            await _aboutDal.AddAsync(about);

            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            await _aboutDal.DeleteAsync(new About { Id = id });

            return true;
        }

        public async Task<About> GetAboutAsync(int id)
        {
            return await _aboutDal.GetAsync(x => x.Id == id && x.IsDeleted == false);
        }

        public async Task<About> GetAboutAsync(string languageCode)
        {
            return await _aboutDal.GetAboutAsync(languageCode);
        }

        public async Task<List<About>> GetAllAboutsAsync()
        {
            return await _aboutDal.GetAllAsync(x => x.IsDeleted == false);
        }

        public async Task<List<About>> GetAllAboutsAsync(int skipCount, int takeCount)
        {
            return await _aboutDal.GetAboutsByCountAsync(skipCount, takeCount);
        }

        public async Task<About> GetAboutWithLanguageAsync(int id)
        {
            return await _aboutDal.GetAboutWithInclude(id);
        }

        public async Task<bool> UpdateAsync(About about)
        {
            await _aboutDal.UpdateAsync(about);

            return true;
        }
    }
}

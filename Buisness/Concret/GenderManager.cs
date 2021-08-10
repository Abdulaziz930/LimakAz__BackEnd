using Buisness.Abstract;
using DataAccess.Abstract;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Buisness.Concret
{
    public class GenderManager : IGenderService
    {
        private readonly IGenderDal _genderDal;

        public GenderManager(IGenderDal genderDal)
        {
            _genderDal = genderDal;
        }

        public async Task<bool> AddAsync(Gender gender)
        {
            await _genderDal.AddAsync(gender);

            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            await _genderDal.DeleteAsync(new Gender { Id = id });

            return true;
        }

        public async Task<List<Gender>> GetAllGendersAsync(string languageCode)
        {
            return await _genderDal.GetMultiLanguageGendersAsync(languageCode);
        }

        public async Task<List<Gender>> GetAllGendersAsync()
        {
            return await _genderDal.GetAllAsync();
        }

        public async Task<List<Gender>> GetAllGendersAsync(int skipCount, int takeCount)
        {
            return await _genderDal.GetGendersByCountAsync(skipCount, takeCount);
        }

        public async Task<Gender> GetGenderAsync(int id)
        {
            return await _genderDal.GetAsync(x => x.Id == id);
        }

        public async Task<bool> UpdateAsync(Gender gender)
        {
            await _genderDal.UpdateAsync(gender);

            return true;
        }
    }
}

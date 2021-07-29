using Buisness.Abstract;
using DataAccess.Abstract;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Buisness.Concret
{
    public class HowItWorkManager : IHowItWorkService
    {
        private readonly IHowItWorkDal _howItWorkDal;

        public HowItWorkManager(IHowItWorkDal howItWorkDal)
        {
            _howItWorkDal = howItWorkDal;
        }

        public async Task<bool> AddAsync(HowItWork howItWork)
        {
            await _howItWorkDal.AddAsync(howItWork);

            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            await _howItWorkDal.DeleteAsync(new HowItWork { Id = id });

            return true;
        }

        public async Task<List<HowItWork>> GetAllHowItWorksAsync()
        {
            return await _howItWorkDal.GetAllAsync(x => x.IsDeleted == false);
        }

        public async Task<List<HowItWork>> GetAllHowItWorksAsync(int skipCount, int takeCount)
        {
            return await _howItWorkDal.GetHowItWorksByCountAsync(skipCount, takeCount);
        }

        public async Task<HowItWork> GetHowItWorkAsync(int id)
        {
            return await _howItWorkDal.GetAsync(x => x.Id == id && x.IsDeleted == false);
        }

        public async Task<HowItWork> GetHowItWorkAsync(string languageCode)
        {
            return await _howItWorkDal.GetMultiLanguageHowItWorkAsync(languageCode);
        }

        public async Task<HowItWork> GetHowItWorkWithLanguageAsync(int id)
        {
            return await _howItWorkDal.GetHowItWorkWithIncludeAsync(id);
        }

        public async Task<bool> UpdateAsync(HowItWork howItWork)
        {
            await _howItWorkDal.UpdateAsync(howItWork);

            return true;
        }
    }
}

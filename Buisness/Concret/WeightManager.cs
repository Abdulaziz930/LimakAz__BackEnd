using Buisness.Abstract;
using DataAccess.Abstract;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Buisness.Concret
{
    public class WeightManager : IWeightService
    {
        private readonly IWeightDal _weightDal;

        public WeightManager(IWeightDal weightDal)
        {
            _weightDal = weightDal;
        }

        public async Task<bool> AddAsync(Weight weight)
        {
            await _weightDal.AddAsync(weight);

            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            await _weightDal.DeleteAsync(new Weight { Id = id });

            return true;
        }

        public async Task<List<Weight>> GetAllWeightsAsync()
        {
            return await _weightDal.GetAllAsync(x => x.IsDeleted == false);
        }

        public async Task<List<Weight>> GetAllWeightsAsync(string languageCode)
        {
            return await _weightDal.GetAllMultiLanguageWeightsAsync(languageCode);
        }

        public async Task<List<Weight>> GetAllWeightsAsync(int skipCount, int takeCount)
        {
            return await _weightDal.GetWeightByCountAsync(skipCount, takeCount);
        }

        public async Task<Weight> GetWeightAsync(int id)
        {
            return await _weightDal.GetAsync(x => x.Id == id && x.IsDeleted == false);
        }

        public async Task<Weight> GetWeightWithLanguageAsync(int id)
        {
            return await _weightDal.GetWeightWithIncludeAsync(id);
        }

        public async Task<bool> UpdateAsync(Weight weight)
        {
            await _weightDal.UpdateAsync(weight);

            return true;
        }
    }
}

using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Buisness.Abstract
{
    public interface IWeightService
    {
        Task<Weight> GetWeightAsync(int id);

        Task<Weight> GetWeightWithLanguageAsync(int id);

        Task<List<Weight>> GetAllWeightsAsync();

        Task<List<Weight>> GetAllWeightsAsync(string languageCode);

        Task<List<Weight>> GetAllWeightsAsync(int skipCount,int takeCount);

        Task<bool> AddAsync(Weight weight);

        Task<bool> UpdateAsync(Weight weight);

        Task<bool> DeleteAsync(int id);
    }
}

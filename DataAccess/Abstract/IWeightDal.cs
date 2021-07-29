using Core.Repository;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IWeightDal : IRepository<Weight>
    {
        Task<Weight> GetWeightWithIncludeAsync(int id);

        Task<List<Weight>> GetAllMultiLanguageWeightsAsync(string languageCode);

        Task<List<Weight>> GetWeightByCountAsync(int skipCount, int takeCount);
    }
}

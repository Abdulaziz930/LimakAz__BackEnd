using Core.Repository.EFRepository;
using DataAccess.Abstract;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concret
{
    public class EFWeightDal : EFRepositoryBase<Weight, AppDbContext>, IWeightDal
    {
        public EFWeightDal(AppDbContext context) : base(context)
        {
        }

        public async Task<List<Weight>> GetAllMultiLanguageWeightsAsync(string languageCode)
        {
            return await Context.Weights.Include(x => x.Language)
                .Where(x => x.Language.Code == languageCode && x.Language.IsDeleted == false && x.IsDeleted == false).ToListAsync();
        }

        public async Task<List<Weight>> GetWeightByCountAsync(int skipCount, int takeCount)
        {
            return await Context.Weights.Where(x => x.IsDeleted == false)
                .OrderByDescending(x => x.Id).Skip(skipCount).Take(takeCount).ToListAsync();
        }

        public async Task<Weight> GetWeightWithIncludeAsync(int id)
        {
            return await Context.Weights.Include(x => x.Language)
                .FirstOrDefaultAsync(x => x.Id == id && x.IsDeleted == false && x.Language.IsDeleted == false);
        }
    }
}

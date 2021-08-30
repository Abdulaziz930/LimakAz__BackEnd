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
    public class EFCalculatorDal : EFRepositoryBase<Calculator, AppDbContext>, ICalculatorDal
    {
        public EFCalculatorDal(AppDbContext context) : base(context)
        {
        }

        public async Task<Calculator> GetMultiLanguageCalculatorAsync(string languageCode)
        {
            return await Context.Calculators.Include(x => x.Language)
                .FirstOrDefaultAsync(x => x.Language.Code == languageCode && x.IsDeleted == false && x.Language.IsDeleted == false);
        }

        public async Task<List<Calculator>> GetAllCalculatorContentsByCountAsync(int skipCount, int takeCount)
        {
            return await Context.Calculators.Where(x => x.IsDeleted == false)
                .OrderByDescending(x => x.Id).Skip(skipCount).Take(takeCount).ToListAsync();
        }

        public async Task<Calculator> GetCalculatorWithIncludeAsync(int id)
        {
            return await Context.Calculators.Include(x => x.Language)
                .FirstOrDefaultAsync(x => x.Id == id && x.IsDeleted == false && x.Language.IsDeleted == false);
        }
    }
}

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
    public class EFCalculatorInformationContentDal
        : EFRepositoryBase<CalculatorIntormationContent, AppDbContext>, ICalculatorInformationContentDal
    {
        public EFCalculatorInformationContentDal(AppDbContext context) : base(context)
        {
        }

        public async Task<List<CalculatorIntormationContent>> GetCalculatorIntormationContentsAsync(string languageCode)
        {
            return await Context.CalculatorIntormationContents.Include(x => x.Language)
                .Where(x => x.IsDeleted == false && x.Language.IsDeleted == false && x.Language.Code == languageCode).ToListAsync();
        }

        public async Task<List<CalculatorIntormationContent>> GetCalculatorIntormationContentsByCountAsync(int skipCount, int takeCount)
        {
            return await Context.CalculatorIntormationContents
                .Where(x => x.IsDeleted == false).OrderByDescending(x => x.Id)
                .Skip(skipCount).Take(takeCount).ToListAsync();
        }
    }
}

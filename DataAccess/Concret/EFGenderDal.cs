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
    public class EFGenderDal : EFRepositoryBase<Gender, AppDbContext>, IGenderDal
    {
        public EFGenderDal(AppDbContext context) : base(context) 
        {
        }

        public async Task<List<Gender>> GetGendersByCountAsync(int skipCount, int takeCount)
        {
            return await Context.Genders
                .OrderByDescending(x => x.Id)
                .Skip(skipCount).Take(takeCount).ToListAsync();
        }

        public async Task<List<Gender>> GetMultiLanguageGendersAsync(string languageCode)
        {
            return await Context.Genders.Include(x => x.Language)
                .Where(x => x.Language.IsDeleted == false && x.Language.Code == languageCode).ToListAsync();
        }
    }
}

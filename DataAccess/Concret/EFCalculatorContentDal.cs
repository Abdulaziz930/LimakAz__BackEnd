﻿using Core.Repository.EFRepository;
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
    public class EFCalculatorContentDal : EFRepositoryBase<CalculatorContent, AppDbContext>, ICalculatorContentDal
    {
        public EFCalculatorContentDal(AppDbContext context) : base(context)
        {
        }

        public async Task<CalculatorContent> GetCalculatorContentAsync(string languageCode)
        {
            return await Context.CalculatorContents.Include(x => x.Language)
                .FirstOrDefaultAsync(x => x.IsDeleted == false && x.Language.IsDeleted == false && x.Language.Code == languageCode);
        }

        public async Task<List<CalculatorContent>> GetCalculatorContentsByCountAsync(int skipCount, int takeCount)
        {
            return await Context.CalculatorContents
                .Where(x => x.IsDeleted == false).OrderByDescending(x => x.Id)
                .Skip(skipCount).Take(takeCount).ToListAsync();
        }
    }
}

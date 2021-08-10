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
    public class EFRegisterContentDal : EFRepositoryBase<RegisterContent, AppDbContext>, IRegisterContentDal
    {
        public async Task<RegisterContent> GetMultiLanguageRegisterContentAsync(string languageCode)
        {
            await using var context = new AppDbContext();
            return await context.RegisterContents
                .Include(x => x.Language)
                .FirstOrDefaultAsync(x => x.IsDeleted == false && x.Language.IsDeleted == false && x.Language.Code == languageCode);
        }

        public async Task<List<RegisterContent>> GetRegisterContentsByCountAsync(int skipCount, int takeCount)
        {
            await using var context = new AppDbContext();
            return await context.RegisterContents.Where(x => x.IsDeleted == false)
                .Skip(skipCount).Take(takeCount).ToListAsync();
        }

        public async Task<RegisterContent> GetRegisterContentWithInclude(int id)
        {
            await using var context = new AppDbContext();
            return await context.RegisterContents.Include(x => x.Language)
                .FirstOrDefaultAsync(x => x.Id == id && x.IsDeleted == false && x.Language.IsDeleted == false);
        }
    }
}

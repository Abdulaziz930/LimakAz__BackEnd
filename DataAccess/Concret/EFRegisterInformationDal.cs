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
    public class EFRegisterInformationDal : EFRepositoryBase<RegisterInformation, AppDbContext>, IRegisterInformationDal
    {
        public async Task<RegisterInformation> GetRegisterInformationAsync(string languageCode)
        {
            await using var context = new AppDbContext();
            return await context.RegisterInformations.Include(x => x.Language)
                .FirstOrDefaultAsync(x => x.IsDeleted == false && x.Language.IsDeleted == false && x.Language.Code == languageCode);
        }

        public async Task<List<RegisterInformation>> GetRegisterInformationsByCountAsync(int skipCount, int takeCount)
        {
            await using var context = new AppDbContext();
            return await context.RegisterInformations
                .Where(x => x.IsDeleted == false).OrderByDescending(x => x.Id)
                .Skip(skipCount).Take(takeCount).ToListAsync();
        }
    }
}

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
    public class EFAdvertisementTitleDal : EFRepositoryBase<AdvertisimentTitle, AppDbContext>, IAdvertisementTitleDal
    {

        public async Task<AdvertisimentTitle> GetMultiLanguageAdvertisementTitleAsync(string languageCode)
        {
            await using var context = new AppDbContext();
            return await context.AdvertisimentTitles.Include(x => x.Language)
                .FirstOrDefaultAsync(x => x.Language.Code == languageCode && x.IsDeleted == false && x.Language.IsDeleted == false);
        }

        public async Task<List<AdvertisimentTitle>> GetAllAdvertisementTitlesByCountAsync(int skipCount, int takeCount)
        {
            await using var context = new AppDbContext();
            return await context.AdvertisimentTitles.Where(x => x.IsDeleted == false)
                .OrderByDescending(x => x.Id).Skip(skipCount).Take(takeCount).ToListAsync();
        }
    }
}

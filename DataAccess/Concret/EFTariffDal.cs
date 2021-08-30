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
    public class EFTariffDal : EFRepositoryBase<Tariff, AppDbContext>, ITariffDal
    {
        public EFTariffDal(AppDbContext context) : base(context)
        {
        }

        public async Task<List<Tariff>> GetMultiLanguageTrariffsAsync(string languageCode)
        {
            return await Context.Tariffs.ToListAsync();
        }

        public async Task<List<Country>> GetMultiLanguageTrariffsWithIncludesAsync(string languageCode)
        {
            return await Context.Countries.Include(x => x.Language).Include(x => x.Tab)
                .Where(x => x.Language.Code == languageCode && x.IsDeleted == false).ToListAsync();
        }

        public async Task<List<Tariff>> GetTrariffsWithIncludeAsync(int productTypeId,int countryId)
        {
            return await Context.Tariffs.Include(x => x.ProductType).Include(x => x.Country)
                .Where(x => x.ProductTypeId == productTypeId 
                        && x.ConutryId == countryId && x.IsDeleted == false 
                        && x.ProductType.IsDeleted == false && x.Country.IsDeleted == false).ToListAsync();
        }
    }
}

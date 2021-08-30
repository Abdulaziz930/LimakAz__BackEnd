﻿using Core.Repository.EFRepository;
using DataAccess.Abstract;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concret
{
    public class EFBalanceModalContentDal : EFRepositoryBase<BalanceModalContent, AppDbContext>, IBalanceModalContentDal
    {
        public EFBalanceModalContentDal(AppDbContext context) : base(context)
        {
        }

        public async Task<BalanceModalContent> GetBalanceModalContentAsync(string languageCode)
        {
            return await Context.BalanceModalContents.Include(x => x.Language)
                .FirstOrDefaultAsync(x => x.Language.IsDeleted == false && x.Language.Code == languageCode);
        }
    }
}

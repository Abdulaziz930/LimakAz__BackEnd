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
    public class EFSocialMediaDal : EFRepositoryBase<SocialMedia, AppDbContext>, ISocialMediaDal
    {
        public EFSocialMediaDal(AppDbContext context) : base(context)
        {
        }

        public async Task<List<SocialMedia>> GetSocialMediasByCountAsync(int skipCount, int takeCount)
        {
            return await Context.SocialMedias.Where(x => x.IsDeleted == false)
                .OrderByDescending(x => x.Id).Skip(skipCount).Take(takeCount).ToListAsync();
        }
    }
}

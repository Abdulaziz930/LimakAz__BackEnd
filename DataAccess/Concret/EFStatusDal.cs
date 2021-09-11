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
    public class EFStatusDal : EFRepositoryBase<Status, AppDbContext>, IStatusDal
    {
        public EFStatusDal(AppDbContext context) : base(context)
        {
        }

        public async Task<List<Status>> GetStatusesWithOrders(string languageCode,string userId)
        {
            return await Context.Statuses.Include(x => x.Orders.Where(x => x.StatusId == x.Status.Key 
                && x.AppUserId == userId && x.IsDeleted == false).OrderByDescending(x => x.Id))
                .Include(x => x.Language)
                .Where(x => x.Language.Code == languageCode).ToListAsync();
        }
    }
}

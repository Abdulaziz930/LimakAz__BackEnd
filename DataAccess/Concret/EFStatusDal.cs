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
        public async Task<List<Status>> GetStatusesWithOrders(string languageCode,string userId)
        {
            await using var context = new AppDbContext();
            return await context.Statuses.Include(x => x.Orders.Where(x => x.StatusId == x.Status.Key && x.AppUserId == userId))
                .Include(x => x.Language)
                .Where(x => x.Language.Code == languageCode).ToListAsync();
        }
    }
}

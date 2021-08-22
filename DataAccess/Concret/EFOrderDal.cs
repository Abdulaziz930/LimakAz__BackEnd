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
    public class EFOrderDal : EFRepositoryBase<Order, AppDbContext>, IOrderDal
    {
        public async Task<List<Order>> GetOrdersByCountAsync(int skipCount, int takeCount)
        {
            await using var context = new AppDbContext();
            return await context.Orders
                .OrderByDescending(x => x.Id)
                .Skip(skipCount).Take(takeCount).ToListAsync();
        }
    }
}

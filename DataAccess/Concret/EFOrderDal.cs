using Core.Repository.EFRepository;
using DataAccess.Abstract;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concret
{
    public class EFOrderDal : EFRepositoryBase<Order, AppDbContext>, IOrderDal
    {
        public EFOrderDal(AppDbContext context) : base(context)
        {
        }

        public async Task<Order> GetOrderByFilter(Expression<Func<Order, bool>> expression)
        {
            return await Context.Orders.Include(x => x.Status).Include(x => x.AppUser).FirstOrDefaultAsync(expression);
        }

        public async Task<List<Order>> GetOrdersByCountAsync(int skipCount, int takeCount)
        {
            return await Context.Orders
                .OrderByDescending(x => x.Id)
                .Skip(skipCount).Take(takeCount).ToListAsync();
        }

        public async Task<List<Order>> GetOrdersByCountAsync(string userId, int skipCount, int takeCount)
        {
            return await Context.Orders.Include(x => x.AppUser).Include(x => x.Status)
                .Where(x => x.AppUserId == userId).OrderByDescending(x => x.Id)
                .Skip(skipCount).Take(takeCount).ToListAsync();
        }

        public async Task<List<Order>> GetOrdersByFilter(Expression<Func<Order, bool>> expression, int skipCount, int takeCount)
        {
            return await Context.Orders.Include(x => x.AppUser).Include(x => x.Status)
                .Where(expression).OrderByDescending(x => x.Id)
                .Skip(skipCount).Take(takeCount).ToListAsync();
        }

        public async Task<List<Order>> GetOrdersByFilter(Expression<Func<Order, bool>> expression)
        {
            return await Context.Orders.Include(x => x.AppUser).Include(x => x.Status).Where(expression).ToListAsync();
        }

        public async Task<List<Order>> GetOrdersByUserAsync(string userId)
        {
            return await Context.Orders.Include(x => x.AppUser).Where(x => x.AppUserId == userId).ToListAsync();
        }

        public async Task<Order> GetOrderWithStatus(int id)
        {
            return await Context.Orders.Include(x => x.Status).Include(x => x.AppUser).FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}

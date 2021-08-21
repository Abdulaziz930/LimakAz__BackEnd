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
    public class EFTransactionDal : EFRepositoryBase<Transaction, AppDbContext>, ITransactionDal
    {
        public async Task<Transaction> GetTransactionByUserIdAsync(string userId, int id)
        {
            await using var context = new AppDbContext();
            return await context.Transactions.FirstOrDefaultAsync(x => x.AppUserId == userId && x.Id == id);
        }

        public async Task<List<Transaction>> GetTransactionsByUserIdAsync(string userId,int page = 1)
        {
            await using var context = new AppDbContext();
            return await context.Transactions.Where(x => x.AppUserId == userId)
                .OrderByDescending(x => x.DateTime).Skip((page - 1) * 5).Take(5).ToListAsync();
        }

        public async Task<List<Transaction>> GetTransactionsByUserIdAsync(string userId)
        {
            await using var context = new AppDbContext();
            return await context.Transactions.Where(x => x.AppUserId == userId).ToListAsync();
        }
    }
}

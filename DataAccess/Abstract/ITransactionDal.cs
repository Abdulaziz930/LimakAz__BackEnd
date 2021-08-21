using Core.Repository;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface ITransactionDal : IRepository<Transaction>
    {
        Task<List<Transaction>> GetTransactionsByUserIdAsync(string userId,int page);

        Task<List<Transaction>> GetTransactionsByUserIdAsync(string userId);

        Task<Transaction> GetTransactionByUserIdAsync(string userId, int id);
    }
}

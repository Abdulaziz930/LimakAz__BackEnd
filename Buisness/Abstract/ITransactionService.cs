using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Buisness.Abstract
{
    public interface ITransactionService
    {
        Task<Transaction> GetTransactionAsync(int id);

        Task<Transaction> GetTransactionAsync(string userId, int id);

        Task<List<Transaction>> GetAllTransactionAsync();

        Task<List<Transaction>> GetAllTransactionAsync(string userId, int page);

        Task<List<Transaction>> GetAllTransactionAsync(string userId);

        Task<bool> AddAsync(Transaction transaction);

        Task<bool> UpdateAsync(Transaction transaction);

        Task<bool> DeleteAsync(int id);
    }
}

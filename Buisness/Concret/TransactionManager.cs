using Buisness.Abstract;
using DataAccess.Abstract;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Buisness.Concret
{
    public class TransactionManager : ITransactionService
    {
        private readonly ITransactionDal _transactionDal;

        public TransactionManager(ITransactionDal transactionDal)
        {
            _transactionDal = transactionDal;
        }

        public async Task<bool> AddAsync(Transaction transaction)
        {
            await _transactionDal.AddAsync(transaction);

            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            await _transactionDal.DeleteAsync(new Transaction { Id = id });

            return true;
        }

        public async Task<List<Transaction>> GetAllTransactionAsync()
        {
            return await _transactionDal.GetAllAsync();
        }

        public async Task<List<Transaction>> GetAllTransactionAsync(string userId, int page)
        {
            return await _transactionDal.GetTransactionsByUserIdAsync(userId, page);
        }

        public async Task<List<Transaction>> GetAllTransactionAsync(string userId)
        {
            return await _transactionDal.GetTransactionsByUserIdAsync(userId);
        }

        public async Task<Transaction> GetTransactionAsync(int id)
        {
            return await _transactionDal.GetAsync(x => x.Id == id);
        }

        public async Task<Transaction> GetTransactionAsync(string userId, int id)
        {
            return await _transactionDal.GetTransactionByUserIdAsync(userId, id);
        }

        public async Task<bool> UpdateAsync(Transaction transaction)
        {
            await _transactionDal.UpdateAsync(transaction);

            return true;
        }
    }
}

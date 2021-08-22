using Buisness.Abstract;
using DataAccess.Abstract;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Buisness.Concret
{
    public class StatusManager : IStatusService
    {
        private readonly IStatusDal _statusDal;

        public StatusManager(IStatusDal statusDal)
        {
            _statusDal = statusDal;
        }

        public async Task<bool> AddAsync(Status status)
        {
            await _statusDal.AddAsync(status);

            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            await _statusDal.DeleteAsync(new Status { Id = id });

            return true;
        }

        public async Task<List<Status>> GetAllStatusesAsync()
        {
            return await _statusDal.GetAllAsync();
        }

        public async Task<List<Status>> GetAllStatusesAsync(string languageCode, string userId)
        {
            return await _statusDal.GetStatusesWithOrders(languageCode, userId);
        }

        public async Task<Status> GetStatusAsync(int id)
        {
            return await _statusDal.GetAsync(x => x.Id == id);
        }

        public async Task<bool> UpdateAsync(Status status)
        {
            await _statusDal.UpdateAsync(status);

            return true;
        }
    }
}

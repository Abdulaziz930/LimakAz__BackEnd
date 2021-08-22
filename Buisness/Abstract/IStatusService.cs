using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Buisness.Abstract
{
    public interface IStatusService
    {
        Task<Status> GetStatusAsync(int id);

        Task<List<Status>> GetAllStatusesAsync();

        Task<List<Status>> GetAllStatusesAsync(string languageCode, string userId);

        Task<bool> AddAsync(Status status);

        Task<bool> UpdateAsync(Status status);

        Task<bool> DeleteAsync(int id);
    }
}

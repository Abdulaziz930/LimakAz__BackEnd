using Core.Repository;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IStatusDal : IRepository<Status>
    {
        Task<List<Status>> GetStatusesWithOrders(string languageCode, string userId);
    }
}

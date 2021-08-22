using Core.Repository;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IOrderDal : IRepository<Order>
    {
        Task<List<Order>> GetOrdersByCountAsync(int skipCount, int takeCount);
    }
}

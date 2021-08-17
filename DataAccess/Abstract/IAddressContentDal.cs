using Core.Repository;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IAddressContentDal : IRepository<AddressContent>
    {
        Task<List<Country>> GetAddressContentsAsync(string languageCode);

        Task<List<AddressContent>> GetAddressContentsByCountAsync(int skipCount, int takeCount);
    }
}

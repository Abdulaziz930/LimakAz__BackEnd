using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Buisness.Abstract
{
    public interface IAddressContentService
    {
        Task<AddressContent> GetAddressContentAsync(int id);

        Task<List<AddressContent>> GetAllAddressContentsAsync();

        Task<List<Country>> GetAddressContentsAsync(string languageCode);

        Task<List<AddressContent>> GetAllAddressContentsAsync(int skipCount, int takeCount);

        Task<bool> AddAsync(AddressContent addressContent);

        Task<bool> UpdateAsync(AddressContent addressContent);

        Task<bool> DeleteAsync(int id);
    }
}

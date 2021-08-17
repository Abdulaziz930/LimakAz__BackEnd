using Buisness.Abstract;
using DataAccess.Abstract;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Buisness.Concret
{
    public class AddressContentManager : IAddressContentService
    {
        private readonly IAddressContentDal _addressContentDal;

        public AddressContentManager(IAddressContentDal addressContentDal)
        {
            _addressContentDal = addressContentDal;
        }

        public async Task<bool> AddAsync(AddressContent addressContent)
        {
            await _addressContentDal.AddAsync(addressContent);

            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            await _addressContentDal.DeleteAsync(new AddressContent { Id = id });

            return true;
        }

        public async Task<AddressContent> GetAddressContentAsync(int id)
        {
            return await _addressContentDal.GetAsync(x => x.Id == id);
        }

        public async Task<List<Country>> GetAddressContentsAsync(string languageCode)
        {
            return await _addressContentDal.GetAddressContentsAsync(languageCode);
        }

        public async Task<List<AddressContent>> GetAllAddressContentsAsync()
        {
            return await _addressContentDal.GetAllAsync();
        }

        public async Task<List<AddressContent>> GetAllAddressContentsAsync(int skipCount, int takeCount)
        {
            return await _addressContentDal.GetAddressContentsByCountAsync(skipCount, takeCount);
        }

        public async Task<bool> UpdateAsync(AddressContent addressContent)
        {
            await _addressContentDal.UpdateAsync(addressContent);

            return true;
        }
    }
}

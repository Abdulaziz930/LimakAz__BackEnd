using Buisness.Abstract;
using DataAccess.Abstract;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Buisness.Concret
{
    public class TariffHeaderManager : ITariffHeaderService
    {
        private readonly ITariffHeaderDal _tariffHeaderDal;

        public TariffHeaderManager(ITariffHeaderDal tariffHeaderDal)
        {
            _tariffHeaderDal = tariffHeaderDal;
        }

        public async Task<bool> AddAsync(TariffHeader tariffHeader)
        {
            await _tariffHeaderDal.AddAsync(tariffHeader);

            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            await _tariffHeaderDal.DeleteAsync(new TariffHeader { Id = id });

            return true;
        }

        public async Task<List<TariffHeader>> GetAllTariffHeadersAsync()
        {
            return await _tariffHeaderDal.GetAllAsync(x => x.IsDeleted == false);
        }

        public async Task<List<TariffHeader>> GetAllTariffHeadersAsync(int skipCount, int takeCount)
        {
            return await _tariffHeaderDal.GetTariffHeadersByCountAsync(skipCount, takeCount);
        }

        public async Task<TariffHeader> GetTariffHeaderAsync(int id)
        {
            return await _tariffHeaderDal.GetAsync(x => x.Id == id && x.IsDeleted == false);
        }

        public async Task<TariffHeader> GetTariffHeaderAsync(string languageCode)
        {
            return await _tariffHeaderDal.GetTariffHeaderAsync(languageCode);
        }

        public async Task<bool> UpdateAsync(TariffHeader tariffHeader)
        {
            await _tariffHeaderDal.UpdateAsync(tariffHeader);

            return true;
        }
    }
}

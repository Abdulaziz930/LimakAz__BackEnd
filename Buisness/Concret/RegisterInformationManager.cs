using Buisness.Abstract;
using DataAccess.Abstract;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Buisness.Concret
{
    public class RegisterInformationManager : IRegisterInformationService
    {
        private readonly IRegisterInformationDal _registerInformationDal;

        public RegisterInformationManager(IRegisterInformationDal registerInformationDal)
        {
            _registerInformationDal = registerInformationDal;
        }

        public async Task<bool> AddAsync(RegisterInformation registerInformation)
        {
            await _registerInformationDal.AddAsync(registerInformation);

            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            await _registerInformationDal.DeleteAsync(new RegisterInformation { Id = id });

            return true;
        }

        public async Task<List<RegisterInformation>> GetAllRegisterInformationsAsync()
        {
            return await _registerInformationDal.GetAllAsync(x => x.IsDeleted == false);
        }

        public async Task<List<RegisterInformation>> GetAllRegisterInformationsAsync(int skipCount, int takeCount)
        {
            return await _registerInformationDal.GetRegisterInformationsByCountAsync(skipCount, takeCount);
        }

        public async Task<RegisterInformation> GetRegisterInformationAsync(int id)
        {
            return await _registerInformationDal.GetAsync(x => x.Id == id && x.IsDeleted == false);
        }

        public async Task<RegisterInformation> GetRegisterInformationAsync(string languageCode)
        {
            return await _registerInformationDal.GetRegisterInformationAsync(languageCode);
        }

        public async Task<bool> UpdateAsync(RegisterInformation registerInformation)
        {
            await _registerInformationDal.UpdateAsync(registerInformation);

            return true;
        }
    }
}

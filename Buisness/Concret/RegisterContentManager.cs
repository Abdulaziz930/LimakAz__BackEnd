using Buisness.Abstract;
using DataAccess.Abstract;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Buisness.Concret
{
    public class RegisterContentManager : IRegisterContentService
    {
        private readonly IRegisterContentDal _registerContentDal;

        public RegisterContentManager(IRegisterContentDal registerContentDal)
        {
            _registerContentDal = registerContentDal;
        }

        public async Task<bool> AddAsync(RegisterContent registerContent)
        {
            await _registerContentDal.AddAsync(registerContent);

            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            await _registerContentDal.DeleteAsync(new RegisterContent { Id = id });

            return true;
        }

        public async Task<List<RegisterContent>> GetAllRegisterContentsAsync()
        {
            return await _registerContentDal.GetAllAsync(x => x.IsDeleted == false);
        }

        public async Task<List<RegisterContent>> GetAllRegisterContentsAsync(int skipCount, int takeCount)
        {
            return await _registerContentDal.GetRegisterContentsByCountAsync(skipCount, takeCount);
        }

        public async Task<RegisterContent> GetRegisterContentAsync(int id)
        {
            return await _registerContentDal.GetAsync(x => x.Id == id && x.IsDeleted == false);
        }

        public async Task<RegisterContent> GetRegisterContentAsync(string langaugeCode)
        {
            return await _registerContentDal.GetMultiLanguageRegisterContentAsync(langaugeCode);
        }

        public async Task<RegisterContent> GetRegisterContentWithLanguageAsync(int id)
        {
            return await _registerContentDal.GetRegisterContentWithInclude(id);
        }

        public async Task<bool> UpdateAsync(RegisterContent registerContent)
        {
            await _registerContentDal.UpdateAsync(registerContent);

            return true;
        }
    }
}

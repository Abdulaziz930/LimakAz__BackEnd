using Buisness.Abstract;
using DataAccess.Abstract;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Buisness.Concret
{
    public class ForgotPasswordContentManager : IForgotPasswordContentService
    {
        private readonly IForgotPasswordContentDal _forgotPasswordContentDal;

        public ForgotPasswordContentManager(IForgotPasswordContentDal forgotPasswordContentDal)
        {
            _forgotPasswordContentDal = forgotPasswordContentDal;
        }

        public async Task<bool> AddAsync(ForgotPasswordContent forgotPasswordContent)
        {
            await _forgotPasswordContentDal.AddAsync(forgotPasswordContent);

            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            await _forgotPasswordContentDal.DeleteAsync(new ForgotPasswordContent { Id = id });

            return true;
        }

        public async Task<List<ForgotPasswordContent>> GetAllForgotPasswordContentsAsync()
        {
            return await _forgotPasswordContentDal.GetAllAsync();
        }

        public async Task<List<ForgotPasswordContent>> GetAllForgotPasswordContentsAsync(int skipCount, int takeCount)
        {
            return await _forgotPasswordContentDal.GetForgotPasswordContentsByCountAsync(skipCount, takeCount);
        }

        public async Task<ForgotPasswordContent> GetForgotPasswordContentAsync(int id)
        {
            return await _forgotPasswordContentDal.GetAsync(x => x.Id == id);
        }

        public async Task<ForgotPasswordContent> GetForgotPasswordContentAsync(string languageCode)
        {
            return await _forgotPasswordContentDal.GetForgotPasswordContentAsync(languageCode);
        }

        public async Task<bool> UpdateAsync(ForgotPasswordContent forgotPasswordContent)
        {
            await _forgotPasswordContentDal.UpdateAsync(forgotPasswordContent);

            return true;
        }
    }
}

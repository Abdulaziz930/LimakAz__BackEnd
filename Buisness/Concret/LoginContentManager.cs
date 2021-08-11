using Buisness.Abstract;
using DataAccess.Abstract;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Buisness.Concret
{
    public class LoginContentManager : ILoginContentService
    {
        private readonly ILoginContentDal _loginContentDal;

        public LoginContentManager(ILoginContentDal loginContentDal)
        {
            _loginContentDal = loginContentDal;
        }

        public async Task<bool> AddAsync(LoginContent loginContent)
        {
            await _loginContentDal.AddAsync(loginContent);

            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            await _loginContentDal.DeleteAsync(new LoginContent { Id = id });

            return true;
        }

        public async Task<List<LoginContent>> GetAllLoginContentsAsync()
        {
            return await _loginContentDal.GetAllAsync();
        }

        public async Task<List<LoginContent>> GetAllLoginContentsAsync(int skipCount, int takeCount)
        {
            return await _loginContentDal.GetLoginContentsByCountAsync(skipCount, takeCount);
        }

        public async Task<LoginContent> GetLoginContentAsync(int id)
        {
            return await _loginContentDal.GetAsync(x => x.Id == id);
        }

        public async Task<LoginContent> GetLoginContentAsync(string languageCode)
        {
            return await _loginContentDal.GetLoginContentAsync(languageCode);
        }

        public async Task<bool> UpdateAsync(LoginContent loginContent)
        {
            await _loginContentDal.UpdateAsync(loginContent);

            return true;
        }
    }
}

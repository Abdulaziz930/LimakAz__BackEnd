using Buisness.Abstract;
using DataAccess.Abstract;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Buisness.Concret
{
    public class SettingContentManager : ISettingContentService
    {
        private readonly ISettingContentDal _settingContentDal;

        public SettingContentManager(ISettingContentDal settingContentDal)
        {
            _settingContentDal = settingContentDal;
        }

        public async Task<bool> AddAsync(SettingContent settingContent)
        {
            await _settingContentDal.AddAsync(settingContent);

            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            await _settingContentDal.DeleteAsync(new SettingContent { Id = id });

            return true;
        }

        public async Task<List<SettingContent>> GetAllSettingContentsAsync()
        {
            return await _settingContentDal.GetAllAsync();
        }

        public async Task<SettingContent> GetSettingContentAsync(int id)
        {
            return await _settingContentDal.GetAsync(x => x.Id == id);
        }

        public async Task<SettingContent> GetSettingContentAsync(string languageCode)
        {
            return await _settingContentDal.GetSettingContentAsync(languageCode);
        }

        public async Task<bool> UpdateAsync(SettingContent settingContent)
        {
            await _settingContentDal.UpdateAsync(settingContent);

            return true;
        }
    }
}

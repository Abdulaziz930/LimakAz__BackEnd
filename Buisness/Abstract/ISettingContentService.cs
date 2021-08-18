using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Buisness.Abstract
{
    public interface ISettingContentService
    {
        Task<SettingContent> GetSettingContentAsync(int id);

        Task<SettingContent> GetSettingContentAsync(string languageCode);

        Task<List<SettingContent>> GetAllSettingContentsAsync();

        Task<bool> AddAsync(SettingContent settingContent);

        Task<bool> UpdateAsync(SettingContent settingContent);

        Task<bool> DeleteAsync(int id);
    }
}

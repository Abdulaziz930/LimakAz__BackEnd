using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Buisness.Abstract
{
    public interface ISocialMediaService
    {
        Task<SocialMedia> GetSocialMediaAsync(int id);

        Task<List<SocialMedia>> GetAllSocialMediasAsync();

        Task<List<SocialMedia>> GetAllSocialMediasAsync(int skipCount, int takeCount);

        Task<bool> AddAsync(SocialMedia socialMedia);

        Task<bool> UpdateAsync(SocialMedia socialMedia);

        Task<bool> DeleteAsync(int id);
    }
}

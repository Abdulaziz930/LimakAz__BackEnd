using Buisness.Abstract;
using DataAccess.Abstract;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Buisness.Concret
{
    public class SocialMediaManager : ISocialMediaService
    {
        private readonly ISocialMediaDal _socialMediaDal;

        public SocialMediaManager(ISocialMediaDal socialMediaDal)
        {
            _socialMediaDal = socialMediaDal;
        }

        public async Task<bool> AddAsync(SocialMedia socialMedia)
        {
            await _socialMediaDal.AddAsync(socialMedia);

            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            await _socialMediaDal.DeleteAsync(new SocialMedia { Id = id });

            return true;
        }

        public async Task<List<SocialMedia>> GetAllSocialMediasAsync()
        {
            return await _socialMediaDal.GetAllAsync(x => x.IsDeleted == false);
        }

        public async Task<List<SocialMedia>> GetAllSocialMediasAsync(int skipCount, int takeCount)
        {
            return await _socialMediaDal.GetSocialMediasByCountAsync(skipCount, takeCount);
        }

        public async Task<SocialMedia> GetSocialMediaAsync(int id)
        {
            return await _socialMediaDal.GetAsync(x => x.Id == id && x.IsDeleted == false);
        }

        public async Task<bool> UpdateAsync(SocialMedia socialMedia)
        {
            await _socialMediaDal.UpdateAsync(socialMedia);

            return true;
        }
    }
}

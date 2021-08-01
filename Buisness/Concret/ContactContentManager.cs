using Buisness.Abstract;
using DataAccess.Abstract;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Buisness.Concret
{
    public class ContactContentManager : IContactContentService
    {
        private readonly IContactContentDal _contactContentDal;

        public ContactContentManager(IContactContentDal contactContentDal)
        {
            _contactContentDal = contactContentDal;
        }

        public async Task<bool> AddAsync(ContactContent contactContent)
        {
            await _contactContentDal.AddAsync(contactContent);

            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            await _contactContentDal.DeleteAsync(new ContactContent { Id = id });

            return true;
        }

        public async Task<List<ContactContent>> GetAllContactContentsAsync()
        {
            return await _contactContentDal.GetAllAsync(x => x.IsDeleted == false);
        }

        public async Task<List<ContactContent>> GetAllContactContentsAsync(int skipCount, int takeCount)
        {
            return await _contactContentDal.GetContactContentsByCountAsync(skipCount, takeCount);
        }

        public async Task<ContactContent> GetContactContentAsync(int id)
        {
            return await _contactContentDal.GetAsync(x => x.Id == id);
        }

        public async Task<ContactContent> GetContactContentAsync(string languageCode)
        {
            return await _contactContentDal.GetContactContent(languageCode);
        }

        public async Task<bool> UpdateAsync(ContactContent contactContent)
        {
            await _contactContentDal.UpdateAsync(contactContent);

            return true;
        }
    }
}

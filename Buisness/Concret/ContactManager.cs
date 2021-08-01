using Buisness.Abstract;
using DataAccess.Abstract;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Buisness.Concret
{
    public class ContactManager : IContactService
    {
        private readonly IContactDal _contactDal;

        public ContactManager(IContactDal contactDal)
        {
            _contactDal = contactDal;
        }

        public async Task<bool> AddAsync(Contact contact)
        {
            await _contactDal.AddAsync(contact);

            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            await _contactDal.DeleteAsync(new Contact { Id = id });

            return true;
        }

        public async Task<List<Contact>> GetAllContactsAsync()
        {
            return await _contactDal.GetAllAsync(x => x.IsDeleted == false);
        }

        public async Task<List<Contact>> GetAllContactsAsync(int skipCount, int takeCount)
        {
            return await _contactDal.GetContactsByCountAsync(skipCount, takeCount);
        }

        public async Task<List<City>> GetAllContactsAsync(string languageCode)
        {
            return await _contactDal.GetContacts(languageCode);
        }

        public async Task<Contact> GetContactAsync(int id)
        {
            return await _contactDal.GetAsync(x => x.Id == id && x.IsDeleted == false);
        }

        public async Task<City> GetContactAsync(string languageCode)
        {
            return await _contactDal.GetContact(languageCode);
        }

        public async Task<bool> UpdateAsync(Contact contact)
        {
            await _contactDal.UpdateAsync(contact);

            return true;
        }
    }
}

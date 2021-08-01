using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Buisness.Abstract
{
    public interface IContactService
    {
        Task<Contact> GetContactAsync(int id);

        Task<City> GetContactAsync(string languageCode);

        Task<List<Contact>> GetAllContactsAsync();

        Task<List<Contact>> GetAllContactsAsync(int skipCount, int takeCount);

        Task<List<City>> GetAllContactsAsync(string languageCode);

        Task<bool> AddAsync(Contact contact);

        Task<bool> UpdateAsync(Contact contact);

        Task<bool> DeleteAsync(int id);
    }
}

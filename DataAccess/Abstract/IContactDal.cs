using Core.Repository;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IContactDal : IRepository<Contact>
    {
        Task<List<City>> GetContacts(string languageCode);

        Task<City> GetContact(string languageCode);

        Task<List<Contact>> GetContactsByCountAsync(int skipCount, int takeCount);
    }
}

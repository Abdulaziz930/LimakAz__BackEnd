using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Buisness.Abstract
{
    public interface IContactContentService
    {
        Task<ContactContent> GetContactContentAsync(int id);

        Task<ContactContent> GetContactContentAsync(string languageCode);

        Task<List<ContactContent>> GetAllContactContentsAsync();

        Task<List<ContactContent>> GetAllContactContentsAsync(int skipCount, int takeCount);

        Task<bool> AddAsync(ContactContent contactContent);

        Task<bool> UpdateAsync(ContactContent contactContent);

        Task<bool> DeleteAsync(int id);
    }
}

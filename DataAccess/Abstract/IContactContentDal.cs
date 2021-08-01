using Core.Repository;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IContactContentDal : IRepository<ContactContent>
    {
        Task<ContactContent> GetContactContent(string languageCode);

        Task<List<ContactContent>> GetContactContentsByCountAsync(int skipCount, int takeCount);
    }
}

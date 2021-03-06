using Core.Repository.EFRepository;
using DataAccess.Abstract;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concret
{
    public class EFContactDal : EFRepositoryBase<Contact, AppDbContext>, IContactDal
    {
        public EFContactDal(AppDbContext context) : base(context) 
        {
        }

        public async Task<City> GetContact(string languageCode)
        {
            return await Context.Cities.Include(x => x.Language)
                .Include(x => x.Contacts).FirstOrDefaultAsync(x => x.Language.Code == languageCode 
                && x.IsDeleted == false && x.Language.IsDeleted == false
                && x.Contacts.Any(x => x.IsDeleted == false));
        }

        public async Task<List<City>> GetContacts(string languageCode)
        {
            return await Context.Cities.Include(x => x.Language)
                .Include(x => x.Contacts).ThenInclude(x => x.Services)
                .Where(x => x.Language.Code == languageCode && x.IsDeleted == false && x.Language.IsDeleted == false
                && x.Contacts.Any(x => x.IsDeleted == false && x.Services.Any(x => x.IsDeleted == false))).ToListAsync();
        }

        public async Task<List<Contact>> GetContactsByCountAsync(int skipCount, int takeCount)
        {
            return await Context.Contacts.Where(x => x.IsDeleted == false).OrderByDescending(x => x.Id)
                .Skip(skipCount).Take(takeCount).ToListAsync();
        }
    }
}

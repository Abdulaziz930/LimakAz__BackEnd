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
    public class EFCertificateDal : EFRepositoryBase<Certificate, AppDbContext>, ICertificateDal
    {

        public async Task<Certificate> GetMultiLanguageCertificateAsync(string languageCode)
        {
            await using var context = new AppDbContext();
            return await context.Certificates.Include(x => x.Language)
                .FirstOrDefaultAsync(x => x.Language.Code == languageCode && x.IsDeleted == false && x.Language.IsDeleted == false);
        }

        public async Task<List<Certificate>> GetAllCertificateContentsByCountAsync(int skipCount, int takeCount)
        {
            await using var context = new AppDbContext();
            return await context.Certificates.Where(x => x.IsDeleted == false)
                .OrderByDescending(x => x.Id).Skip(skipCount).Take(takeCount).ToListAsync();
        }

        public async Task<Certificate> GetCertifcateWithIncludeAsync(int id)
        {
            await using var context = new AppDbContext();
            return await context.Certificates.Include(x => x.Language)
                .FirstOrDefaultAsync(x => x.Id == id && x.IsDeleted == false && x.Language.IsDeleted == false);
        }
    }
}

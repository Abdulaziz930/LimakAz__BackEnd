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
    public class EFCertificateContentDal : EFRepositoryBase<CertifcateContent, AppDbContext>, ICertificateContentDal
    {
        public EFCertificateContentDal(AppDbContext context) : base(context)
        {
        }

        public async Task<List<CertifcateContent>> GetAllCertificateContentsByCountAsync(int skipCount, int takeCount)
        {
            return await Context.CertifcateContents.Where(x => x.IsDeleted == false)
                .OrderByDescending(x => x.Id).Skip(skipCount).Take(takeCount).ToListAsync();
        }
    }
}

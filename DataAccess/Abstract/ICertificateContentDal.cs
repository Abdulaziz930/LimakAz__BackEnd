using Core.Repository;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface ICertificateContentDal : IRepository<CertifcateContent>
    {
        Task<List<CertifcateContent>> GetAllCertificateContentsByCountAsync(int skipCount, int takeCount);
    }
}

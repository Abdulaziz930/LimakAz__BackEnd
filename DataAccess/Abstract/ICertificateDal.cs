using Core.Repository;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface ICertificateDal : IRepository<Certificate>
    {
        Task<Certificate> GetMultiLanguageCertificateAsync(string languageCode);

        Task<Certificate> GetCertifcateWithIncludeAsync(int id);

        Task<List<Certificate>> GetAllCertificateContentsByCountAsync(int skipCount, int takeCount);
    }
}

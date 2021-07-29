using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Buisness.Abstract
{
    public interface ICertificateContentService
    {
        Task<CertifcateContent> GetCertificateAsync(int id);

        Task<List<CertifcateContent>> GetAllCertificatesAsync();

        Task<List<CertifcateContent>> GetAllCertificatesAsync(int skipCount,int takeCount);

        Task<bool> AddAsync(CertifcateContent certificateContent);

        Task<bool> UpdateAsync(CertifcateContent certificateContent);

        Task<bool> DeleteAsync(int id);
    }
}

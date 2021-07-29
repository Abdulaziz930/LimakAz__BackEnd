using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Buisness.Abstract
{
    public interface ICertificateService
    {
        Task<Certificate> GetCertificateAsync(int id);

        Task<Certificate> GetCertificateWithLanguageAsync(int id);

        Task<Certificate> GetCertificateAsync(string languageCode);

        Task<List<Certificate>> GetAllCertificateContentsAsync();

        Task<List<Certificate>> GetAllCertificateContentsAsync(int skipCount, int takeCount);

        Task<bool> AddAsync(Certificate certificate);

        Task<bool> UpdateAsync(Certificate certificate);

        Task<bool> DeleteAsync(int id);
    }
}

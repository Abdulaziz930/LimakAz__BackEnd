using Buisness.Abstract;
using DataAccess.Abstract;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Buisness.Concret
{
    public class CertificateManager : ICertificateService
    {
        private readonly ICertificateDal _certificateDal;

        public CertificateManager(ICertificateDal certificateDal)
        {
            _certificateDal = certificateDal;
        }

        public async Task<bool> AddAsync(Certificate certificate)
        {
            await _certificateDal.AddAsync(certificate);

            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            await _certificateDal.DeleteAsync(new Certificate { Id = id });

            return true;
        }

        public async Task<List<Certificate>> GetAllCertificateContentsAsync()
        {
            return await _certificateDal.GetAllAsync(x => x.IsDeleted == false);
        }

        public async Task<List<Certificate>> GetAllCertificateContentsAsync(int skipCount, int takeCount)
        {
            return await _certificateDal.GetAllCertificateContentsByCountAsync(skipCount, takeCount);
        }

        public async Task<Certificate> GetCertificateAsync(int id)
        {
            return await _certificateDal.GetAsync(x => x.Id == id && x.IsDeleted == false);
        }

        public async Task<Certificate> GetCertificateAsync(string languageCode)
        {
            return await _certificateDal.GetMultiLanguageCertificateAsync(languageCode);
        }

        public async Task<Certificate> GetCertificateWithLanguageAsync(int id)
        {
            return await _certificateDal.GetCertifcateWithIncludeAsync(id);
        }

        public async Task<bool> UpdateAsync(Certificate certificate)
        {
            await _certificateDal.UpdateAsync(certificate);

            return true;
        }
    }
}

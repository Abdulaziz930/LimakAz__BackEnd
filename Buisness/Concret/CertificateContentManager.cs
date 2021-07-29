using Buisness.Abstract;
using DataAccess.Abstract;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Buisness.Concret
{
    public class CertificateContentManager : ICertificateContentService
    {
        private readonly ICertificateContentDal _certificateDal;

        public CertificateContentManager(ICertificateContentDal certificateDal)
        {
            _certificateDal = certificateDal;
        }

        public async Task<bool> AddAsync(CertifcateContent certificateContent)
        {
            await _certificateDal.AddAsync(certificateContent);

            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            await _certificateDal.DeleteAsync(new CertifcateContent { Id = id });

            return true;
        }

        public async Task<List<CertifcateContent>> GetAllCertificatesAsync()
        {
            return await _certificateDal.GetAllAsync(x => x.IsDeleted == false);
        }

        public async Task<List<CertifcateContent>> GetAllCertificatesAsync(int skipCount, int takeCount)
        {
            return await _certificateDal.GetAllCertificateContentsByCountAsync(skipCount, takeCount);
        }

        public async Task<CertifcateContent> GetCertificateAsync(int id)
        {
            return await _certificateDal.GetAsync(x => x.Id == id && x.IsDeleted == false);
        }

        public async Task<bool> UpdateAsync(CertifcateContent certificate)
        {
            await _certificateDal.UpdateAsync(certificate);

            return true;
        }
    }
}

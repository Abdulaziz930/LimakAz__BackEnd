using Core.Repository;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IRegisterInformationDal : IRepository<RegisterInformation>
    {
        Task<RegisterInformation> GetRegisterInformationAsync(string languageCode);

        Task<List<RegisterInformation>> GetRegisterInformationsByCountAsync(int skipCount, int takeCount);
    }
}

using Core.Repository;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface ITariffHeaderDal : IRepository<TariffHeader>
    {
        Task<TariffHeader> GetTariffHeaderAsync(string languageCode);

        Task<List<TariffHeader>> GetTariffHeadersByCountAsync(int skipCount, int takeCount);
    }
}

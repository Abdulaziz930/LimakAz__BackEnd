using Core.Repository;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IProductTypeDal : IRepository<ProductType>
    {
        Task<ProductType> GetProductTypeWithIncludeAsync(int id);

        Task<List<ProductType>> GetAllMultiLanguageProductTypeAsync(string languageCode);

        Task<List<ProductType>> GetAllMultiLanguageProductTypeWhithIncludeAsync(string languageCode);

        Task<List<ProductType>> GetProductTypesByCountAsync(int skipCount, int takeCount);
    }
}

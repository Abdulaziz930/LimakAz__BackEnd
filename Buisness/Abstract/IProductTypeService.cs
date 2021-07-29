using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Buisness.Abstract
{
    public interface IProductTypeService
    {
        Task<ProductType> GetProductTypeAsync(int id);

        Task<ProductType> GetProductTypeWithLanguageAsync(int id);

        Task<List<ProductType>> GetAllProductTypesAsync();

        Task<List<ProductType>> GetAllProductTypesAsync(string languageCode);

        Task<List<ProductType>> GetAllProductTypesAsync(int skipCount,int takeCount);

        Task<bool> AddAsync(ProductType productType);

        Task<bool> UpdateAsync(ProductType productType);

        Task<bool> DeleteAsync(int id);
    }
}

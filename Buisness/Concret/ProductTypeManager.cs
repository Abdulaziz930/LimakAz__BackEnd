using Buisness.Abstract;
using DataAccess.Abstract;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Buisness.Concret
{
    public class ProductTypeManager : IProductTypeService
    {
        private readonly IProductTypeDal _productTypeDal;

        public ProductTypeManager(IProductTypeDal productTypeDal)
        {
            _productTypeDal = productTypeDal;
        }

        public async Task<bool> AddAsync(ProductType productType)
        {
            await _productTypeDal.AddAsync(productType);

            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            await _productTypeDal.DeleteAsync(new ProductType { Id = id });

            return true;
        }

        public async Task<List<ProductType>> GetAllProductTypesAsync()
        {
            return await _productTypeDal.GetAllAsync(x => x.IsDeleted == false);
        }

        public async Task<List<ProductType>> GetAllProductTypesAsync(string languageCode)
        {
            return await _productTypeDal.GetAllMultiLanguageProductTypeAsync(languageCode);
        }

        public async Task<List<ProductType>> GetAllProductTypesAsync(int skipCount, int takeCount)
        {
            return await _productTypeDal.GetProductTypesByCountAsync(skipCount, takeCount);
        }

        public async Task<List<ProductType>> GetAllProductTypesWithTariffAsync(string languageCode)
        {
            return await _productTypeDal.GetAllMultiLanguageProductTypeWhithIncludeAsync(languageCode);
        }

        public async Task<ProductType> GetProductTypeAsync(int id)
        {
            return await _productTypeDal.GetAsync(x => x.Id == id);
        }

        public async Task<ProductType> GetProductTypeWithLanguageAsync(int id)
        {
            return await _productTypeDal.GetProductTypeWithIncludeAsync(id);
        }

        public async Task<bool> UpdateAsync(ProductType productType)
        {
            await _productTypeDal.UpdateAsync(productType);

            return true;
        }
    }
}
